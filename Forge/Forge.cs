using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace Forge
{
    public partial class Forge : Form
    {
        public Forge()
        {
            InitializeComponent();
        }

        public class TimeSpan : IComparable
        {
            public int start_sec = 0;
            public int end_sec = 0;

            public int length()
            {
                return end_sec - start_sec;
            }
            public bool overlaps(TimeSpan other)
            {
                if (other.end_sec <= start_sec)
                    return false;
                if (other.start_sec >= end_sec)
                    return false;
                return true;
            }
            public static TimeSpan union(TimeSpan A, TimeSpan B)
            {
                TimeSpan ret = new TimeSpan();
                ret.start_sec = Math.Min(A.start_sec, B.start_sec);
                ret.end_sec = Math.Max(A.end_sec, B.end_sec);
                return ret;
            }
            public int CompareTo(object other)
            {
                return start_sec.CompareTo(((TimeSpan)other).start_sec);
            }
            public void CopyFrom(TimeSpan other)
            {
                start_sec = other.start_sec;
                end_sec = other.end_sec;
            }
        };

        public class CodTaskTimespans
        {
            public TimeSpan nat_play = new TimeSpan();
            public TimeSpan free_play = new TimeSpan();
            public TimeSpan still_face = new TimeSpan();
            public TimeSpan reunion = new TimeSpan();
        };

        [DataContract]
        public class CachedDecisions
        {
            // These are things entered for a data directory that we don't want
            // to have to reopen every time.
            [DataMember]
            public Dictionary<string, CodTaskTimespans> reliability_baselines = new Dictionary<string, CodTaskTimespans>();

            [DataMember]
            public int saved_epoch_amount;

            [DataMember]
            public Dictionary<string, string> accepted_coders = new Dictionary<string, string>();
        };

        class CodFile
        {
            public XmlDocument xml;
            public string source_file_name;

            public string coder;
            public CodVideo video;

            public ListViewItem list_view_item;

            public List<string> errors = new List<string>();

            // each task has a timespan that it is valid over.
            public CodTaskTimespans timespans = new CodTaskTimespans();

            // parsed timespans for codes.
            public List<TimeSpan> baby_invisible = new List<TimeSpan>();
            public List<TimeSpan> orient_object = new List<TimeSpan>();
            public List<TimeSpan> orient_mother = new List<TimeSpan>();
            public List<TimeSpan> self_soothe = new List<TimeSpan>();
            public List<TimeSpan> escape = new List<TimeSpan>();

            public void parse_task(string task_name, TimeSpan output_span)
            {
                XmlNode task_1 = xml.SelectSingleNode("/code/tracks/track[@name=\"" + task_name + "\"]");
                XmlNodeList spans = task_1.SelectNodes("span");

                List<TimeSpan> parsed_spans = new List<TimeSpan>();
                foreach (XmlNode span in spans)
                {
                    TimeSpan new_span = new TimeSpan();
                    new_span.start_sec = Int32.Parse(span.SelectSingleNode("@start").InnerText);
                    new_span.end_sec = Int32.Parse(span.SelectSingleNode("@end").InnerText);
                    parsed_spans.Add(new_span);
                }

                if (parsed_spans.Count == 0)
                {
                    errors.Add(video.video + " - " + coder + " - " + task_name + " has no spans.");
                    return;
                }

                //
                // Strictly speaking, only one span can exist. However due to the UI in Spanner,
                // we could get hidden spans "behind" another, or we can have extensions that overlap
                // or are adjacent. So we only error if there distinct spans.
                //
                // In order to make sure that the spans can join without any ordering nonsense, we sort
                // by start time.
                //
                parsed_spans.Sort();

                //
                // Now we try to join them. The only way we fail is if the union of the
                // timespans _adds_ time to the total of both - which would means there's
                // a space between them that got added by the union operation.
                //
                output_span.CopyFrom(parsed_spans[0]);
                for (int i = 1; i < parsed_spans.Count; i++)
                {
                    TimeSpan U = TimeSpan.union(output_span, parsed_spans[i]);
                    if (U.length() > output_span.length() + parsed_spans[i].length())
                    {
                        // failure mode - some space was added.
                        errors.Add(video.video + " - " + coder + " - " + task_name + " has more than one distinct span.");
                        return;
                    }

                    // otherwise, we just use the union in case we got extensions or whatnot.
                    output_span.CopyFrom(U);
                }
            }

            public void parse_spans(string track_name, List<TimeSpan> measure)
            {
                XmlNode hidden = xml.SelectSingleNode("/code/tracks/track[@name=\"" + track_name + "\"]");
                XmlNodeList spans = hidden.SelectNodes("span");
                foreach (XmlNode s in spans)
                {
                    TimeSpan new_span = new TimeSpan();
                    new_span.start_sec = Int32.Parse(s.SelectSingleNode("@start").InnerText);
                    new_span.end_sec = Int32.Parse(s.SelectSingleNode("@end").InnerText);
                    measure.Add(new_span);
                }
            }
        };

        class CodVideo
        {
            // Video ID string (ie filename)
            public string video;

            // Each video can be coded many times.
            public List<CodFile> codes = new List<CodFile>();

            // The epoch parsed codes for each coder who did this video.
            // Generated during reliability export - not loaded from disc.
            public List<Reliability> reliability = new List<Reliability>();

            public CodFile GetCodFileByCoder(string coder)
            {
                foreach (CodFile cf in codes)
                {
                    if (cf.coder == coder)
                        return cf;
                }
                return null;
            }

        };

        List<CodFile> ErrorFiles = new List<CodFile>();
        Dictionary<string, CodVideo> Videos = new Dictionary<string, CodVideo>();
        public CachedDecisions Decisions = new CachedDecisions();
        string DetectedTimepoint;

        void save_decisions()
        {
            if (lblPath.Text == "")
                return;

            var serializer = new DataContractSerializer(typeof(CachedDecisions));
            var sw = new StringWriter();
            var writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented; // indent the Xml so it's human readable
            serializer.WriteObject(writer, Decisions);

            File.WriteAllText(lblPath.Text + "\\cached_decisions.xml", sw.ToString());
        }

        private void Forge_Load(object sender, EventArgs e)
        {
            txtEpoch.Text = "5";
        }

        private string seconds_to_string(int time)
        {
            int minutes = time / 60;
            int seconds = time % 60;
            string minutes_str = minutes.ToString();
            string seconds_str = seconds < 10 ? ("0" + seconds.ToString()) : seconds.ToString();
            return minutes_str + ":" + seconds_str;
        }

        private void lstVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selected_items = lstVideos.SelectedItems;
            if (selected_items.Count == 0)
            {
                // deselected.
                txtNatPlayStart.Text = "";
                txtNatPlayEnd.Text = "";
                txtFreePlayEnd.Text = "";
                txtFreePlayStart.Text = "";
                txtStillEnd.Text = "";
                txtStillStart.Text = "";
                txtReunionEnd.Text = "";
                txtReunionStart.Text = "";
            }
            else
            {
                ListViewItem selected_item = selected_items[0];
                CodVideo selected_video = Videos[selected_item.Text];

                if (Decisions.reliability_baselines.ContainsKey(selected_video.video))
                {
                    // show the values.
                    CodTaskTimespans reliability_timespans = Decisions.reliability_baselines[selected_video.video];

                    txtNatPlayStart.Text = seconds_to_string(reliability_timespans.nat_play.start_sec);
                    txtNatPlayEnd.Text = seconds_to_string(reliability_timespans.nat_play.end_sec);
                    txtFreePlayStart.Text = seconds_to_string(reliability_timespans.free_play.start_sec);
                    txtFreePlayEnd.Text = seconds_to_string(reliability_timespans.free_play.end_sec);
                    txtStillStart.Text = seconds_to_string(reliability_timespans.still_face.start_sec);
                    txtStillEnd.Text = seconds_to_string(reliability_timespans.still_face.end_sec);
                    txtReunionStart.Text = seconds_to_string(reliability_timespans.reunion.start_sec);
                    txtReunionEnd.Text = seconds_to_string(reliability_timespans.reunion.end_sec);
                }
                else
                {
                    // deselect.
                    txtNatPlayStart.Text = "";
                    txtNatPlayEnd.Text = "";
                    txtFreePlayEnd.Text = "";
                    txtFreePlayStart.Text = "";
                    txtStillEnd.Text = "";
                    txtStillStart.Text = "";
                    txtReunionEnd.Text = "";
                    txtReunionStart.Text = "";
                }
            }
        }


        private void lstVideos_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = false;
            folder.Description = "Select folder with COD files.";
            if (folder.ShowDialog() != DialogResult.OK)
                return;

            btnLoad.Enabled = false;

            lblPath.Text = folder.SelectedPath;

            // Look for any cached decisions
            try
            {
                using (StreamReader decision_stream = new StreamReader(folder.SelectedPath + "\\cached_decisions.xml"))
                {
                    XmlTextReader decision_reader = new XmlTextReader(decision_stream);
                    DataContractSerializer loader = new DataContractSerializer(typeof(CachedDecisions));
                    Decisions = (CachedDecisions)loader.ReadObject(decision_reader);

                    txtEpoch.Text = Decisions.saved_epoch_amount.ToString();
                }
            }
            catch (Exception)
            {
                // file wasn't there.
            }

            Videos.Clear();
            lstVideos.Items.Clear();

            int file_count = 0;
            IEnumerable<string> files = Directory.EnumerateFiles(folder.SelectedPath, "*.cod");
            foreach (string file in files)
            {
                file_count++;

                XmlDocument loaded_xml = new XmlDocument();
                loaded_xml.Load(file);

                XmlNode video_node = loaded_xml.SelectSingleNode("/code/file");
                string video_key = video_node.InnerText;

                CodVideo video = null;
                if (Videos.ContainsKey(video_key) == false)
                {
                    video = new CodVideo();
                    video.video = video_key;
                    Videos[video_key] = video;
                }
                else
                    video = Videos[video_key];

                if (DetectedTimepoint == null)
                {
                    DetectedTimepoint = video.video.Substring(0, 2);
                    lblTimepoint.Text = DetectedTimepoint;
                }

                CodFile codfile = new CodFile();
                video.codes.Add(codfile);

                codfile.source_file_name = file;
                codfile.video = video;
                codfile.xml = loaded_xml;
                
                XmlNode coder_node = loaded_xml.SelectSingleNode("/code/coder");
                codfile.coder = coder_node.InnerText;


                // parse the tracks.

                // The task tracks should ONLY have one track.
                codfile.parse_task("Naturalistic Play", codfile.timespans.nat_play);
                codfile.parse_task("Free Play", codfile.timespans.free_play);
                codfile.parse_task("Still Face", codfile.timespans.still_face);
                codfile.parse_task("Reunion", codfile.timespans.reunion);

                codfile.parse_spans("Baby Hidden", codfile.baby_invisible);
                codfile.parse_spans("Orient: Object", codfile.orient_object);
                codfile.parse_spans("Orient: Mother", codfile.orient_mother);
                codfile.parse_spans("Self Soothe", codfile.self_soothe);
                codfile.parse_spans("Escape", codfile.escape);

                if (codfile.errors.Count != 0)
                {
                    // remove from the videos list and add to the errors list.
                    video.codes.Remove(codfile);
                    ErrorFiles.Add(codfile);
                }
            }

            lblVideoCount.Text = Videos.Count.ToString();
            lblFileCount.Text = file_count.ToString();
            lblErrorCount.Text = ErrorFiles.Count.ToString();
            if (ErrorFiles.Count != 0)
            {
                lblErrorCount.ForeColor = Color.Red;
                lblError.ForeColor = Color.Red;
            }

            foreach (CodFile file in ErrorFiles)
            {
                foreach (string error in file.errors)
                {
                    lstErrors.Items.Add(error);
                }
            }

            foreach (KeyValuePair<string, CodVideo> pair in Videos)
            {
                CodVideo video = pair.Value;

                foreach (CodFile file in video.codes)
                {
                    string[] entries = new string[4];

                    entries[0] = video.video;
                    entries[1] = file.coder;

                    entries[2] = "";
                    if (video.codes.Count > 1)
                    {
                        if (Decisions.accepted_coders.ContainsKey(video.video) &&
                            Decisions.accepted_coders[video.video] == file.coder)
                            entries[2] = "YES";
                        else
                            entries[2] = "no";

                    }

                    entries[3] = "";
                    if (video.codes.Count > 1)
                    {
                        if (Decisions.reliability_baselines.ContainsKey(video.video))
                            entries[3] = "no";
                        else
                            entries[3] = "YES";
                    }

                    ListViewItem item = new ListViewItem(entries);
                    lstVideos.Items.Add(item);
                    file.list_view_item = item;
                }
            }
        }

        void sync_list_view()
        {
            foreach (KeyValuePair<string, CodVideo> pair in Videos)
            {
                CodVideo video = pair.Value;

                foreach (CodFile file in video.codes)
                {
                    if (video.codes.Count > 1)
                    {
                        if (Decisions.accepted_coders.ContainsKey(video.video) &&
                            Decisions.accepted_coders[video.video] == file.coder)
                            file.list_view_item.SubItems[2].Text = "YES";
                        else
                            file.list_view_item.SubItems[2].Text = "no";
                    }

                    if (video.codes.Count > 1)
                    {
                        if (Decisions.reliability_baselines.ContainsKey(video.video))
                            file.list_view_item.SubItems[3].Text = "no";
                        else
                            file.list_view_item.SubItems[3].Text = "YES";
                    }
                }
            }
        }

        private void parse_time_input(TextBox owner, ref int time)
        {
            // If there's a colon, then parse as MM:SS.
            int index_of_colon = owner.Text.IndexOf(':');
            if (index_of_colon != -1)
            {
                string minutes = owner.Text.Substring(0, index_of_colon);
                string seconds = owner.Text.Substring(index_of_colon + 1);

                int new_minutes = 0;
                int new_seconds = 0;
                if (Int32.TryParse(minutes, out new_minutes) &&
                    Int32.TryParse(seconds, out new_seconds))
                {
                    time = new_minutes * 60 + new_seconds;
                    
                    owner.Text = seconds_to_string(time);
                }
            }
            else
            {
                int new_seconds = 0;
                if (Int32.TryParse(owner.Text, out new_seconds))
                {
                    time = new_seconds;

                    owner.Text = seconds_to_string(time);
                }
            }
        }

        private void txtNatPlayStart_Leave(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count == 0)
                return; // we are setting the text from code - don't parse, or nothing is selected.

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return; // don't need reliability.

            if (Decisions.reliability_baselines.ContainsKey(selected_video.video) == false)
                Decisions.reliability_baselines[selected_video.video] = new CodTaskTimespans();

            parse_time_input(txtNatPlayStart, ref Decisions.reliability_baselines[selected_video.video].nat_play.start_sec);
            sync_list_view();
        }

        private void txtNatPlayEnd_Leave(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count == 0)
                return; // we are setting the text from code - don't parse, or nothing is selected.

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return; // don't need reliability.

            if (Decisions.reliability_baselines.ContainsKey(selected_video.video) == false)
                Decisions.reliability_baselines[selected_video.video] = new CodTaskTimespans();

            parse_time_input(txtNatPlayEnd, ref Decisions.reliability_baselines[selected_video.video].nat_play.end_sec);
            sync_list_view();
        }

        private void txtFreePlayStart_Leave(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count == 0)
                return; // we are setting the text from code - don't parse, or nothing is selected.

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return; // don't need reliability.

            if (Decisions.reliability_baselines.ContainsKey(selected_video.video) == false)
                Decisions.reliability_baselines[selected_video.video] = new CodTaskTimespans();

            parse_time_input(txtFreePlayStart, ref Decisions.reliability_baselines[selected_video.video].free_play.start_sec);
            sync_list_view();
        }

        private void txtFreePlayEnd_Leave(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count == 0)
                return; // we are setting the text from code - don't parse, or nothing is selected.

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return; // don't need reliability.

            if (Decisions.reliability_baselines.ContainsKey(selected_video.video) == false)
                Decisions.reliability_baselines[selected_video.video] = new CodTaskTimespans();

            parse_time_input(txtFreePlayEnd, ref Decisions.reliability_baselines[selected_video.video].free_play.end_sec);
            sync_list_view();
        }

        private void txtStillStart_Leave(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count == 0)
                return; // we are setting the text from code - don't parse, or nothing is selected.

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return; // don't need reliability.

            if (Decisions.reliability_baselines.ContainsKey(selected_video.video) == false)
                Decisions.reliability_baselines[selected_video.video] = new CodTaskTimespans();

            parse_time_input(txtStillStart, ref Decisions.reliability_baselines[selected_video.video].still_face.start_sec);
            sync_list_view();
        }

        private void txtStillEnd_Leave(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count == 0)
                return; // we are setting the text from code - don't parse, or nothing is selected.

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return; // don't need reliability.

            if (Decisions.reliability_baselines.ContainsKey(selected_video.video) == false)
                Decisions.reliability_baselines[selected_video.video] = new CodTaskTimespans();

            parse_time_input(txtStillEnd, ref Decisions.reliability_baselines[selected_video.video].still_face.end_sec);
            sync_list_view();
        }

        private void txtReunionStart_Leave(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count == 0)
                return; // we are setting the text from code - don't parse, or nothing is selected.

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return; // don't need reliability.

            if (Decisions.reliability_baselines.ContainsKey(selected_video.video) == false)
                Decisions.reliability_baselines[selected_video.video] = new CodTaskTimespans();

            parse_time_input(txtReunionStart, ref Decisions.reliability_baselines[selected_video.video].reunion.start_sec);
            sync_list_view();
        }

        private void txtReunionEnd_Leave(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count == 0)
                return; // we are setting the text from code - don't parse, or nothing is selected.

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return; // don't need reliability.

            if (Decisions.reliability_baselines.ContainsKey(selected_video.video) == false)
                Decisions.reliability_baselines[selected_video.video] = new CodTaskTimespans();

            parse_time_input(txtReunionEnd, ref Decisions.reliability_baselines[selected_video.video].reunion.end_sec);
            sync_list_view();
        }
        
        enum TaskType
        {
            eNaturalPlay,
            eFreePlay,
            eStillFace,
            eReunion
        };

        enum MeasureType
        {
            eBabyInvis,
            eEscape,
            eMother,
            eObject,
            eSoothe
        };

        class ReliabilityTask
        {
            public List<bool> baby_invisible = new List<bool>();
            public List<bool> escape = new List<bool>();
            public List<bool> orient_mother = new List<bool>();
            public List<bool> orient_object = new List<bool>();
            public List<bool> self_soothe = new List<bool>();

            public List<bool> GetMeasure(MeasureType type)
            {
                switch (type)
                {
                    case MeasureType.eBabyInvis: return baby_invisible;
                    case MeasureType.eEscape: return escape;
                    case MeasureType.eMother: return orient_mother;
                    case MeasureType.eObject: return orient_object;
                    case MeasureType.eSoothe: return self_soothe;
                }
                return null;
            }
        };
        class Reliability : IComparable
        {
            public string coder;

            public ReliabilityTask nat_play = new ReliabilityTask();
            public ReliabilityTask free_play = new ReliabilityTask();
            public ReliabilityTask still_face = new ReliabilityTask();
            public ReliabilityTask reunion = new ReliabilityTask();

            public int CompareTo(object other)
            {
                return coder.CompareTo(((Reliability)other).coder);
            }
            public ReliabilityTask get_task(TaskType task) 
            {
                switch (task)
                {
                    case TaskType.eNaturalPlay: return nat_play;
                    case TaskType.eFreePlay: return free_play;
                    case TaskType.eReunion: return reunion;
                    case TaskType.eStillFace: return still_face;
                }
                throw new Exception();
            }
            public static string get_task_str(TaskType task)
            {
                switch (task)
                {
                    case TaskType.eNaturalPlay: return "natpl";
                    case TaskType.eFreePlay: return "freepl";
                    case TaskType.eReunion: return "reun";
                    case TaskType.eStillFace: return "stillf";
                }
                throw new Exception();
            }
            public static string get_task_abbrev(TaskType task)
            {
                switch (task)
                {
                    case TaskType.eNaturalPlay: return "np";
                    case TaskType.eFreePlay: return "fp";
                    case TaskType.eReunion: return "re";
                    case TaskType.eStillFace: return "sf";
                }
                throw new Exception();
            }
            public static string get_measure_str(MeasureType measure)
            {
                switch (measure)
                {
                    case MeasureType.eBabyInvis: return "binvis";
                    case MeasureType.eEscape: return "escape";
                    case MeasureType.eMother: return "omother";
                    case MeasureType.eObject: return "oobject";
                    case MeasureType.eSoothe: return "ssoothe";
                }
                throw new Exception();
            }
            public static string get_measure_abbrev(MeasureType measure)
            {
                switch (measure)
                {
                    case MeasureType.eBabyInvis: return "inv";
                    case MeasureType.eEscape: return "esc";
                    case MeasureType.eMother: return "mom";
                    case MeasureType.eObject: return "obj";
                    case MeasureType.eSoothe: return "soo";
                }
                throw new Exception();
            }
            public void run_measure(TimeSpan epoch, List<bool> epoch_markings, List<TimeSpan> codes)
            {
                bool epoch_marked = false;
                foreach (TimeSpan span in codes)
                {
                    if (span.overlaps(epoch))
                    {
                        epoch_marked = true;
                        break;
                    }
                }

                epoch_markings.Add(epoch_marked);
            }

            public void run_task(ReliabilityTask task, TimeSpan task_time, CodFile code, int epoch_len_sec)
            {
                int current_epoch_start = task_time.start_sec;
                for (; current_epoch_start < task_time.end_sec; current_epoch_start += epoch_len_sec)
                {
                    TimeSpan epoch = new TimeSpan();
                    epoch.start_sec = current_epoch_start;
                    epoch.end_sec = current_epoch_start + epoch_len_sec;

                    run_measure(epoch, task.baby_invisible, code.baby_invisible);
                    run_measure(epoch, task.escape, code.escape);
                    run_measure(epoch, task.orient_mother, code.orient_mother);
                    run_measure(epoch, task.orient_object, code.orient_object);
                    run_measure(epoch, task.self_soothe, code.self_soothe);
                }
            }
        };

        private void btnReliability_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.Description = "Select folder to write CSVs and SPSS Syntax.";
            if (folder.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Decisions.saved_epoch_amount = Int32.Parse(txtEpoch.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Epoch must be specified as a number.");
                return;
            }

            save_decisions();

            //
            // We find every video that has multpile coders, then we compare their coding
            // to the baseline for the video.
            //
            //
            int epoch_len_sec = Decisions.saved_epoch_amount;


            //
            // Files look like:
            // epoch, coder_baby_inivis, coder_orient_object, coder_orient_mother, coder_escape, coder_self_soothe, coder_2_baby_invis, ...
            //
            // Each file is 1 video
            //
            List<CodVideo> needs_baseline = new List<CodVideo>();
            foreach (KeyValuePair<string, CodVideo> pair in Videos)
            {
                CodVideo video = pair.Value;

                if (video.codes.Count < 1)
                    continue; // not a reliability video

                if (Decisions.reliability_baselines.ContainsKey(video.video) == false)
                {
                    needs_baseline.Add(video);
                    continue; // no baseline to compare vs
                }

                StringBuilder Kappas = new StringBuilder();
                StringBuilder syntax = new StringBuilder();
                syntax.Append("DATASET ACTIVATE NameOfDataSetHere.\r\n");

                CodTaskTimespans reliability_baselines = Decisions.reliability_baselines[video.video];

                video.reliability.Clear();

                // Iterate over the task timespans, outputting whether the code was set
                // for each epoch, for each coder.
                foreach (CodFile code in video.codes)
                {
                    Reliability r = new Reliability();
                    r.coder = code.coder;

                    r.run_task(r.free_play, reliability_baselines.free_play, code, epoch_len_sec);
                    r.run_task(r.nat_play, reliability_baselines.nat_play, code, epoch_len_sec);
                    r.run_task(r.reunion, reliability_baselines.reunion, code, epoch_len_sec);
                    r.run_task(r.still_face, reliability_baselines.still_face, code, epoch_len_sec);

                    video.reliability.Add(r);
                }

                video.reliability.Sort();

                bool has_primary_coder = video.reliability[0].coder == "9000";

                for (int outer = 0; outer < (has_primary_coder ? 1 : video.reliability.Count); outer++)
                {
                    Reliability OuterR = (Reliability)video.reliability[outer];
                    for (int inner = outer + 1; inner < video.reliability.Count; inner++)
                    {
                        Reliability InnerR = (Reliability)video.reliability[inner];

                        Reliability one = OuterR;
                        Reliability two = InnerR;

                        //
                        // First, we want to get the Baby Invisible kappa, since other measures
                        // are dependent on it.
                        //
                        {
                            int count_00 = 0;
                            int count_11 = 0;
                            int count_01 = 0;
                            int count_10 = 0;

                            foreach (TaskType task in Enum.GetValues(typeof(TaskType)))
                            {
                                ReliabilityTask one_task = one.get_task(task);
                                ReliabilityTask two_task = two.get_task(task);

                                for (int i = 0; i < one_task.GetMeasure(MeasureType.eBabyInvis).Count; i++)
                                {
                                    bool one_value = one_task.GetMeasure(MeasureType.eBabyInvis)[i];
                                    bool two_value = two_task.GetMeasure(MeasureType.eBabyInvis)[i];

                                    if (one_value && two_value)
                                        count_11++;
                                    else if (one_value && !two_value)
                                        count_10++;
                                    else if (!one_value && two_value)
                                        count_01++;
                                    else
                                        count_00++;
                                }
                            }

                            float den_count = (float)(count_00 + count_01 + count_10 + count_11);
                            float p0 = (count_11 + count_00) / den_count;
                            float py = ((count_11 + count_01) / den_count) * ((count_11 + count_10) / den_count);
                            float pn = ((count_00 + count_01) / den_count) * ((count_00 + count_10) / den_count);
                            float pe = py + pn;
                            Kappas.AppendFormat("{3} {0}x{1} {2}\r\n", one.coder, two.coder, (p0 - pe) / (1 - pe), Reliability.get_measure_str(MeasureType.eBabyInvis));
                        }

                        //
                        // Now we need each other measure's kappa, except we need to exclude
                        // from the counts if EITHER coder set BI.
                        //
                        foreach (MeasureType measure in Enum.GetValues(typeof(MeasureType)))
                        {
                            if (measure == MeasureType.eBabyInvis)
                                continue;

                            int count_00 = 0;
                            int count_11 = 0;
                            int count_01 = 0;
                            int count_10 = 0;
                            int count_total = 0;

                            foreach (TaskType task in Enum.GetValues(typeof(TaskType)))
                            {
                                ReliabilityTask one_task = one.get_task(task);
                                ReliabilityTask two_task = two.get_task(task);

                                List<bool> one_measure = one_task.GetMeasure(measure);
                                List<bool> two_measure = two_task.GetMeasure(measure);
                                List<bool> one_invisible = one_task.GetMeasure(MeasureType.eBabyInvis);
                                List<bool> two_invisible = two_task.GetMeasure(MeasureType.eBabyInvis);

                                for (int i = 0; i < one_measure.Count; i++)
                                {
                                    count_total++;
                                    if (one_invisible[i] ||
                                        two_invisible[i])
                                        continue; // consider it a missing value if either coded BI.

                                    bool one_value = one_measure[i];
                                    bool two_value = two_measure[i];

                                    if (one_value && two_value)
                                        count_11++;
                                    else if (one_value && !two_value)
                                        count_10++;
                                    else if (!one_value && two_value)
                                        count_01++;
                                    else
                                        count_00++;
                                }
                            }

                            float den_count = (float)(count_00 + count_01 + count_10 + count_11);
                            float p0 = (count_11 + count_00) / den_count;
                            float py = ((count_11 + count_01) / den_count) * ((count_11 + count_10) / den_count);
                            float pn = ((count_00 + count_01) / den_count) * ((count_00 + count_10) / den_count);
                            float pe = py + pn;
                            Kappas.AppendFormat("{2} {0}x{1} {3} {4}/{5}\r\n", one.coder, two.coder, Reliability.get_measure_str(measure), (p0 - pe) / (1 - pe), den_count, count_total);
                        }
                    }
                }

                {
                    syntax.Append("*-----------------------------.\r\n");
                    syntax.AppendFormat("* {0} Kappa Syntax.\r\n", video.video);
                    syntax.AppendFormat("* Associated data generated At {0} second epoch.\r\n", epoch_len_sec);
                    syntax.Append("*-----------------------------.\r\n");


                    //
                    // Write out the SPSS syntax to run the reliability. If Steph is one of the coders,
                    // only check the coder against her video. If not, then we check every unique pair.
                    //
                    // This happens for each code.                    
                    // Need each combo.
                    for (int outer = 0; outer < (has_primary_coder ? 1 : video.reliability.Count); outer++)
                    {
                        Reliability OuterR = (Reliability)video.reliability[outer];
                        for (int inner = outer + 1; inner < video.reliability.Count; inner++)
                        {
                            Reliability InnerR = (Reliability)video.reliability[inner];

                            syntax.Append("*---------------.\r\n");
                            syntax.AppendFormat("* {0} x {1}.\r\n", OuterR.coder, InnerR.coder);
                            syntax.Append("*---------------.\r\n");

                            for (int code = 0; code < 5; code++)
                            {
                                char code_key = '-';
                                string code_string = "";
                                switch (code)
                                {
                                    case 0: code_key = 'b'; code_string = "baby hidden"; break;
                                    case 1: code_key = 'o'; code_string = "orient object"; break;
                                    case 2: code_key = 'm'; code_string = "orient mother"; break;
                                    case 3: code_key = 'e'; code_string = "escape"; break;
                                    case 4: code_key = 's'; code_string = "self soothe"; break;
                                }
                                syntax.AppendFormat("* {0}.\r\n", code_string);
                                syntax.Append("CROSSTABS\r\n");
                                syntax.AppendFormat("  /TABLES={2}{1} by {2}{0}\r\n", OuterR.coder, InnerR.coder, code_key);
                                syntax.Append("  /FORMAT=AVALUE TABLES\r\n");
                                syntax.Append("  /STATISTICS=KAPPA\r\n");
                                syntax.Append("  /CELLS=COUNT\r\n");
                                syntax.Append("  /COUNT ROUND CELL.\r\n");
                                syntax.Append("\r\n");
                            }
                        }
                    }
                } // end syntax gen

                // Write out the reliability for the video.
                // Each row touches each coder, bleh
                StringBuilder SB = new StringBuilder();
                SB.Append("epoch,");
                for (int r = 0; r < video.reliability.Count; r++)
                {
                    Reliability R = (Reliability)video.reliability[r];
                    SB.AppendFormat("b{0},o{0},m{0},e{0},s{0}", R.coder);
                    if (r < video.reliability.Count - 1)
                        SB.Append(",");
                }
                SB.Append("\r\n");

                foreach (TaskType task in Enum.GetValues(typeof(TaskType)))
                {
                    int current_epoch = 0;
                    for (; ; )
                    {
                        if (current_epoch >= video.reliability[0].get_task(task).baby_invisible.Count)
                            break;

                        SB.Append(Reliability.get_task_str(task));
                        SB.Append(current_epoch);
                        SB.Append(",");

                        for (int r = 0; r < video.reliability.Count; r++)
                        {
                            Reliability R = (Reliability)video.reliability[r];
                            ReliabilityTask RT = R.get_task(task);

                            SB.Append(RT.baby_invisible[current_epoch] ? "1," : "0,");
                            SB.Append(RT.orient_object[current_epoch] ? "1," : "0,");
                            SB.Append(RT.orient_mother[current_epoch] ? "1," : "0,");
                            SB.Append(RT.escape[current_epoch] ? "1," : "0,");
                            SB.Append(RT.self_soothe[current_epoch] ? "1" : "0");
                            if (r < video.reliability.Count - 1)
                                SB.Append(",");
                        }

                        SB.Append("\r\n");
                        current_epoch++;
                    }
                }
                File.WriteAllText(folder.SelectedPath + "\\" + video.video + "_kappa_data.txt", SB.ToString());
                File.WriteAllText(folder.SelectedPath + "\\" + video.video + "_kappa_syntax.sps", syntax.ToString());
                File.WriteAllText(folder.SelectedPath + "\\" + video.video + "_kappas.txt", Kappas.ToString());
            } // end for each video

            if (needs_baseline.Count != 0)
            {
                StringBuilder SB = new StringBuilder();
                SB.Append("The following videos don't have valid baseline timespans specified:\r\n");
                foreach (CodVideo v in needs_baseline)
                {
                    SB.AppendFormat("\t{0}\r\n", v.video);
                }

                MessageBox.Show(SB.ToString(), "Baselines Missing");
            }

        }

        private void btnSetBaseline_Click(object sender, EventArgs e)
        {
            // Sets the currently selected spans as the reliability baselines
            // for the video.
            if (lstVideos.SelectedItems.Count == 0)
                return;

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return; // don't need reliability.

            if (Decisions.reliability_baselines.ContainsKey(selected_video.video) == false)
                Decisions.reliability_baselines[selected_video.video] = new CodTaskTimespans();

            string coder = lstVideos.SelectedItems[0].SubItems[1].Text;

            CodFile cf = selected_video.GetCodFileByCoder(coder);
            Decisions.reliability_baselines[selected_video.video].free_play.start_sec = cf.timespans.free_play.start_sec;
            Decisions.reliability_baselines[selected_video.video].free_play.end_sec = cf.timespans.free_play.end_sec;
            Decisions.reliability_baselines[selected_video.video].nat_play.start_sec = cf.timespans.nat_play.start_sec;
            Decisions.reliability_baselines[selected_video.video].nat_play.end_sec = cf.timespans.nat_play.end_sec;
            Decisions.reliability_baselines[selected_video.video].still_face.start_sec = cf.timespans.still_face.start_sec;
            Decisions.reliability_baselines[selected_video.video].still_face.end_sec = cf.timespans.still_face.end_sec;
            Decisions.reliability_baselines[selected_video.video].reunion.start_sec = cf.timespans.reunion.start_sec;
            Decisions.reliability_baselines[selected_video.video].reunion.end_sec = cf.timespans.reunion.end_sec;

            CodTaskTimespans reliability_timespans = Decisions.reliability_baselines[selected_video.video];
            txtNatPlayStart.Text = seconds_to_string(reliability_timespans.nat_play.start_sec);
            txtNatPlayEnd.Text = seconds_to_string(reliability_timespans.nat_play.end_sec);
            txtFreePlayStart.Text = seconds_to_string(reliability_timespans.free_play.start_sec);
            txtFreePlayEnd.Text = seconds_to_string(reliability_timespans.free_play.end_sec);
            txtStillStart.Text = seconds_to_string(reliability_timespans.still_face.start_sec);
            txtStillEnd.Text = seconds_to_string(reliability_timespans.still_face.end_sec);
            txtReunionStart.Text = seconds_to_string(reliability_timespans.reunion.start_sec);
            txtReunionEnd.Text = seconds_to_string(reliability_timespans.reunion.end_sec);

            sync_list_view();

        }

        private void btnAccepted_Click(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItems.Count == 0)
                return;

            CodVideo selected_video = Videos[lstVideos.SelectedItems[0].Text];
            if (selected_video.codes.Count == 1)
                return;

            Decisions.accepted_coders[selected_video.video] = lstVideos.SelectedItems[0].SubItems[1].Text;

            sync_list_view();
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Decisions.saved_epoch_amount = Int32.Parse(txtEpoch.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Epoch must be specified as a number.");
                return;
            }

            save_decisions();

            //
            // Go over EVERY video, and quantize the codes to the requested
            // epoch size, then compute the porportion of set codes for each
            // task / measure.
            //
            int epoch_len_sec = Decisions.saved_epoch_amount;

            // CSV headers.
            StringBuilder SB = new StringBuilder();
            SB.Append("famid,");
            TaskType[] tasks = (TaskType[])Enum.GetValues(typeof(TaskType));
            MeasureType[] measures = (MeasureType[])Enum.GetValues(typeof(MeasureType));

            for (int t = 0; t < tasks.Length; t++)
            {                
                for (int i = 0; i < measures.Length; i++)
                {
                    if (measures[i] == MeasureType.eBabyInvis)
                        continue; // not a data measure.
                    SB.AppendFormat("oi{2}{0}{1}", Reliability.get_task_abbrev(tasks[t]), Reliability.get_measure_abbrev(measures[i]), DetectedTimepoint.Substring(1));
                    if (t != tasks.Length - 1 || i != measures.Length - 1)
                        SB.Append(",");
                }
            }
            SB.Append("\r\n");

            List<CodVideo> needs_accepted = new List<CodVideo>();

            foreach (KeyValuePair<string, CodVideo> pair in Videos)
            {
                CodVideo video = pair.Value;

                CodFile file = video.codes[0];                
                if (video.codes.Count > 1)
                {
                    // Look up the accepted coder.
                    if (Decisions.accepted_coders.ContainsKey(video.video))
                        file = video.GetCodFileByCoder(Decisions.accepted_coders[video.video]);
                    else
                    {
                        // multiple files and one hasn't been marked as the one to use.
                        needs_accepted.Add(video);
                        continue;
                    }
                }

                Reliability r = new Reliability();

                // separate out in to epochs
                r.run_task(r.free_play, file.timespans.free_play, file, epoch_len_sec);
                r.run_task(r.nat_play, file.timespans.nat_play, file, epoch_len_sec);
                r.run_task(r.reunion, file.timespans.reunion, file, epoch_len_sec);
                r.run_task(r.still_face, file.timespans.still_face, file, epoch_len_sec);

                //
                // Need:
                //  famid
                //  measure_task_timepoint
                //
                // video name is TimepointFamid
                // timepoint is 2 characters (A3)
                //
                
                string Famid = video.video.Substring(2);
                SB.Append(Famid);
                SB.Append(",");
                for (int t = 0; t < tasks.Length; t++)
                {                
                    ReliabilityTask task = r.get_task(tasks[t]);

                    List<bool> baby_invis = task.baby_invisible;
                    for (int m = 0; m < measures.Length; m++)
                    {
                        if (measures[m] == MeasureType.eBabyInvis)
                            continue;

                        List<bool> codes = task.GetMeasure(measures[m]);

                        int count_total = 0;
                        int count_coded = 0;
                        for (int i = 0; i < codes.Count; i++)
                        {
                            if (baby_invis[i])
                                continue; // ignore codes when the baby is invis

                            count_total++;
                            if (codes[i])
                                count_coded++;
                        }

                        SB.Append((count_coded / (float)count_total));
                        if (t != tasks.Length - 1 || m != measures.Length - 1)
                            SB.Append(",");
                    }
                }
            } // end for each video

            if (needs_accepted.Count != 0)
            {
                StringBuilder msg = new StringBuilder();
                msg.Append("The following videos don't have valid baseline timespans specified:\r\n");
                foreach (CodVideo v in needs_accepted)
                {
                    msg.AppendFormat("\t{0}\r\n", v.video);
                }

                MessageBox.Show(msg.ToString(), "Baselines Missing");
            }
            File.WriteAllText(saveFileDialog1.FileName, SB.ToString());
        }
    }
}
