using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MidnightOilGames
{
    public partial class Spanner : Form
    {
        public Spanner()
        {
            InitializeComponent();

            Player.uiMode = "none";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "mp4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                Player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(myPlayer_PlayStateChange);
                Player.PositionChange += Player_PositionChange;

                Player.URL = openFileDialog1.FileName;

                string trun = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf('\\') + 1);
                trun = trun.Substring(0, trun.LastIndexOf('.'));

                lblVideo.Text = trun;

                button1.Enabled = false;
                cmdExport.Enabled = true;

                btnLoadCod.Enabled = true;
            }
        }

        private void Player_PositionChange(object sender, AxWMPLib._WMPOCXEvents_PositionChangeEvent e)
        {
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void myPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 3)
            {
                hScrollBar1.Maximum = (int)Player.currentMedia.duration;
                hScrollBar2.Maximum = (int)Player.currentMedia.duration - 60;
            }
        }

        bool suppress_changed = false;

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            if (suppress_changed == false)
            {
                //Console.WriteLine("update");
                Player.Ctlcontrols.pause();                
            }

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // if the cursor is beyond the end of the view range, catch up.
            if (hScrollBar1.Value > hScrollBar2.Value + 60)
            {
                hScrollBar2.Value = Math.Min(hScrollBar2.Maximum, Math.Max(0, hScrollBar1.Value - 15));
            }
            if (hScrollBar1.Value < hScrollBar2.Value)
            {
                hScrollBar2.Value = Math.Min(hScrollBar2.Maximum, Math.Max(0, hScrollBar1.Value - 15));
            }

            if (e.Type == ScrollEventType.EndScroll)
            {
                Player.Ctlcontrols.currentPosition = hScrollBar1.Value;
                Player.Ctlcontrols.play();
                Player.Ctlcontrols.pause();

            }
        }

        static Color[] track_colors =
        {
            Color.Aquamarine,
            Color.CornflowerBlue,
            Color.Tomato,
            Color.SteelBlue,
            Color.SeaGreen,
            Color.Orchid,
            Color.LightSalmon,
            Color.DodgerBlue,
            Color.Brown
        };
        static Brush[] track_brushes =
        {
            new SolidBrush(track_colors[0]),
            new SolidBrush(track_colors[1]),
            new SolidBrush(track_colors[2]),
            new SolidBrush(track_colors[3]),
            new SolidBrush(track_colors[4]),
            new SolidBrush(track_colors[5]),
            new SolidBrush(track_colors[6]),
            new SolidBrush(track_colors[7]),
            new SolidBrush(track_colors[8])
        };
        int selected_track = 0;
        int track_count = 9;

        class span
        {
            public int start, end;
            public int track;
        };

        int new_span_start = -1;

        span selected_span = null;
        List<span>[] track_spans =
        {
            new List<span>(),
            new List<span>(),
            new List<span>(),
            new List<span>(),
            new List<span>(),
            new List<span>(),
            new List<span>(),
            new List<span>(),
            new List<span>()
        };


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < track_count; i++)
            {
                for (int j = 0; j < track_spans[i].Count; j++)
                {
                    span s = track_spans[i][j];
                    float start_x = pictureBox1.Width * s.start / (float)hScrollBar1.Maximum;
                    float end_x = pictureBox1.Width * s.end / (float)hScrollBar1.Maximum;
                    if (s.end == -1)
                        end_x = pictureBox1.Width * hScrollBar1.Value / (float)hScrollBar1.Maximum;
                    if (end_x == start_x)
                        end_x++;

                    e.Graphics.FillRectangle(track_brushes[i], start_x, i*2, end_x - start_x, 2);
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    Player.Ctlcontrols.pause();
                else if (Player.playState == WMPLib.WMPPlayState.wmppsPaused)
                    Player.Ctlcontrols.play();

                e.Handled = true;
            }
        }

        private void f1_hit()
        {
            if (new_span_start == -1)
            {
                new_span_start = hScrollBar1.Value;
                lblAdding.Visible = true;
            }
            else
            {
                lblAdding.Visible = false;
                if (hScrollBar1.Value > new_span_start)
                {
                    span new_span = new span();
                    new_span.start = new_span_start;
                    new_span.end = hScrollBar1.Value;
                    new_span.track = selected_track;
                    track_spans[selected_track].Add(new_span);
                }
                new_span_start = -1;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                e.Handled = true;
            if (e.KeyCode == Keys.F1)
            {
                f1_hit();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                e.Handled = true;
            if (e.KeyCode == Keys.F1)
                e.Handled = true;

        }

        
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            // paint the selected track
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, 0, 18 * selected_track, pictureBox2.Width, 18);

            int pb2_start_time_x = (int)hScrollBar2.Value;
            int pb2_end_time_x = (int)hScrollBar2.Value + 60;

            for (int track = 0; track < track_count; track++)
            {
                for (int i = 0; i < track_spans[track].Count; i++)
                {
                    span s = track_spans[track][i];
                    if (s.end < pb2_start_time_x)
                        continue;
                    if (s.start > pb2_end_time_x)
                        continue;

                    float start_x = pictureBox2.Width * (s.start - pb2_start_time_x) / 60;
                    float end_x = pictureBox2.Width * (s.end - pb2_start_time_x) / 60;
                    
                    e.Graphics.FillRectangle(track_brushes[track], start_x, 18 * track + 2, end_x - start_x, 14);

                    if (selected_span == s)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, start_x, 18 * track + 2, end_x - start_x, 14);
                    }
                }
            }

            if (new_span_start != -1 &&
                hScrollBar1.Value > new_span_start)
            {
                if (hScrollBar1.Value > pb2_start_time_x ||
                    new_span_start < pb2_end_time_x)
                {
                    float start_x = pictureBox2.Width * (new_span_start - pb2_start_time_x) / 60;
                    float end_x = pictureBox2.Width * (hScrollBar1.Value - pb2_start_time_x) / 60;

                    e.Graphics.FillRectangle(track_brushes[selected_track], start_x, 18 * selected_track + 2, end_x - start_x, 14);
                }
            }

            if (hScrollBar1.Value >= pb2_start_time_x &&
                hScrollBar1.Value < pb2_end_time_x)
            {
                int cursor_x = pictureBox2.Width * (hScrollBar1.Value - pb2_start_time_x) / 60;
                e.Graphics.DrawLine(Pens.Black, cursor_x, 0, cursor_x, pictureBox2.Height - 3);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                suppress_changed = true;
                hScrollBar1.Value = (int)Player.Ctlcontrols.currentPosition;
                suppress_changed = false;

                // if the cursor is beyond the end of the view range, catch up.
                if (hScrollBar1.Value > hScrollBar2.Value + 60)
                {
                    hScrollBar2.Value = Math.Min(hScrollBar2.Maximum, Math.Max(0, hScrollBar1.Value - 15));
                }
                if (hScrollBar1.Value < hScrollBar2.Value)
                {
                    hScrollBar2.Value = Math.Min(hScrollBar2.Maximum, Math.Max(0, hScrollBar1.Value - 15));
                }
            }

            if (Player.openState == WMPLib.WMPOpenState.wmposMediaOpen)
                lblPosition.Text = Player.Ctlcontrols.currentPositionString + " / " + Player.currentMedia.durationString;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            int click_time = hScrollBar2.Value + 60 * e.X / pictureBox2.Width;
            int click_track = e.Y / 18;
            if (e.Y - click_track * 18 < 2 ||
                e.Y - click_track * 18 > 16)
                click_track = -1;

            if (click_track >= track_count)
                return;

            if (click_track != -1)
            {
                for (int k = 0; k < track_spans[click_track].Count; k++)
                {
                    span s = track_spans[click_track][k];
                    if (click_time >= s.start &&
                        click_time < s.end)
                    {
                        selected_span = s;
                        lblTrack.Text = track_label(click_track).Text;
                        lblSpanEnd.Text = selected_span.end.ToString();
                        lblSpanStart.Text = selected_span.start.ToString();
                        btnDelete.Enabled = true;
                        pictureBox2.Invalidate();
                        return;
                    }
                }
            }

            hScrollBar1.Value = hScrollBar2.Value + (int)(60 * e.X / (float)pictureBox2.Width);
            Player.Ctlcontrols.currentPosition = hScrollBar2.Value + (int)(60 * e.X / (float)pictureBox2.Width);
            Player.Ctlcontrols.play();
            Player.Ctlcontrols.pause();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        Label track_label(int track)
        {
            switch (track)
            {
                case 0: return lblTask1;
                case 1: return lblTask2;
                case 2: return lblTask3;
                case 3: return lblTask4;
                case 4: return lblBaby;
                case 5: return lblMeasure1;
                case 6: return lblMeasure2;
                case 7: return lblMeasure3;
                case 8: return lblMeasure4;
            }
            return null;
        }

        void select_track(int new_track)
        {
            for (int track = 0; track < track_count; track++)
            {
                if (new_track != track)
                    track_label(track).BackColor = SystemColors.Control;
                else
                    track_label(track).BackColor = track_colors[track];
            }
            
            selected_track = new_track;

            pictureBox2.Invalidate();
        }


        private void lblTask1_MouseClick(object sender, MouseEventArgs e)
        {
            select_track(0);
        }

        private void lblTask2_MouseClick(object sender, MouseEventArgs e)
        {
            select_track(1);
        }

        private void lblTask3_MouseClick(object sender, MouseEventArgs e)
        {
            select_track(2);
        }

        private void lblTask4_MouseClick(object sender, MouseEventArgs e)
        {
            select_track(3);
        }

        private void lblBaby_MouseClick(object sender, MouseEventArgs e)
        {
            select_track(4);
        }

        private void lblMeasure1_MouseClick(object sender, MouseEventArgs e)
        {
            select_track(5);
        }

        private void lblMeasure2_MouseClick(object sender, MouseEventArgs e)
        {
            select_track(6);
        }

        private void lblMeasure3_MouseClick(object sender, MouseEventArgs e)
        {
            select_track(7);
        }

        private void lblMeasure4_MouseClick(object sender, MouseEventArgs e)
        {
            select_track(8);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected_span == null)
                return; // shouldn't happen but eh.

            List<span> spans = track_spans[selected_span.track];
            for (int i = 0; i < spans.Count; i++)
            {
                if (spans[i] == selected_span)
                {
                    spans.RemoveAt(i);
                    selected_span = null;
                    pictureBox2.Invalidate();
                    pictureBox1.Invalidate();
                    lblSpanStart.Text = "";
                    lblSpanEnd.Text = "";
                    lblTrack.Text = "";
                }
            }

            btnDelete.Enabled = false;
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private bool do_save()
        {
            if (txtCoder.Text.Length == 0)
            {
                MessageBox.Show("Please enter your coder id!");
                return false;
            }

            StringBuilder SB = new StringBuilder();
            SB.Append("<code>\r\n");
            SB.Append("\t<version>2</version>\r\n");
            SB.AppendFormat("\t<file>{0}</file>\r\n", lblVideo.Text);
            SB.AppendFormat("\t<coder>{0}</coder>\r\n", txtCoder.Text);
            //SB.AppendFormat("\t<flags sex_revealed=\"{0}\" still_abort=\"{1}\" paci_nat=\"{2}\" paci_free=\"{3}\" paci_still=\"{4}\" paci_reunion=\"{5}\"/>\r\n",
            //    chkSexRevealed.Checked ? 1 : 0,
            //    chkStillFaceAbort.Checked ? 1 : 0,
            //    chkPaciNatPlay.Checked ? 1 : 0,
            //    chkPaciFreePlay.Checked ? 1 : 0,
            //    chkPaciStill.Checked ? 1 : 0,
            //    chkPaciReunion.Checked ? 1 : 0
            //    );
            SB.Append("\t<tracks>\r\n");
            for (int track = 0; track < track_count; track++)
            {
                SB.AppendFormat("\t\t<track name=\"{0}\">\r\n", track_label(track).Text);
                for (int sp = 0; sp < track_spans[track].Count; sp++)
                {
                    span s = track_spans[track][sp];
                    SB.AppendFormat("\t\t\t<span start=\"{0}\" end=\"{1}\"/>\r\n", s.start, s.end);
                }
                SB.Append("\t\t</track>\r\n");
            }
            SB.Append("\t</tracks>\r\n");
            SB.Append("</code>\r\n");

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = lblVideo.Text + "_infant_" + txtCoder.Text + ".cod";
            sfd.Filter = "code files (*.cod)|*.cod|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(sfd.FileName, SB.ToString());
                    return true;
                }
                catch
                {
                    MessageBox.Show("Failed to save! Check target file isn't read only or network/disc isn't down.");
                    return false;
                }
            }
            else
                return false;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            do_save();
        }
        

        private void Spanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmdExport.Enabled == false)
                return; // no need to save if nothing loaded.

            DialogResult result = MessageBox.Show("Save?", "Save?", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                if (do_save() == false)
                {
                    e.Cancel = true;
                }
            }
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void Player_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                f1_hit();
        }

        private void btnLoadCod_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "COD files (*.cod)|*.cod";

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            XmlDocument loaded_xml = new XmlDocument();
            loaded_xml.Load(openFileDialog1.FileName);

            XmlNode video_node = loaded_xml.SelectSingleNode("/code/file");
            string video_key = video_node.InnerText;

            if (video_key != lblVideo.Text)
            {
                MessageBox.Show("Doesn't match loaded video.");
                return;
            }

            txtCoder.Text = loaded_xml.SelectSingleNode("/code/coder").InnerText;
            for (int i = 0; i < track_count; i++)
            {
                XmlNodeList np_spans = loaded_xml.SelectNodes("/code/tracks/track[@name=\"" + track_label(i).Text + "\"]/span");
                foreach (XmlNode xspan in np_spans)
                {
                    int start = Int32.Parse(xspan.SelectSingleNode("@start").InnerText);
                    int end = Int32.Parse(xspan.SelectSingleNode("@end").InnerText);
                    span s = new span();
                    s.start = start;
                    s.end = end;
                    s.track = i;
                    track_spans[i].Add(s);
                }
            }

            //XmlNode flags = loaded_xml.SelectSingleNode("/code/flags");
            //if (flags != null)
            //{
            //    chkPaciFreePlay.Checked = flags.SelectSingleNode("@paci_free").InnerText == "1";
            //    chkPaciNatPlay.Checked = flags.SelectSingleNode("@paci_nat").InnerText == "1";
            //    chkStillFaceAbort.Checked = flags.SelectSingleNode("@still_abort").InnerText == "1";
            //    chkSexRevealed.Checked = flags.SelectSingleNode("@sex_revealed").InnerText == "1";
            //    chkPaciReunion.Checked = flags.SelectSingleNode("@paci_reunion").InnerText == "1";
            //    chkPaciStill.Checked = flags.SelectSingleNode("@paci_still").InnerText == "1";
            //}

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

        }
    }
}
