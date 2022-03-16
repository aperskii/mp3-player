using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace mp3_player
{
    public partial class Form1 : Form
    {
        IWavePlayer Player = new WaveOut();
        AudioFileReader afr;
        string[] list;
        int i;
        float j;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var di = new OpenFileDialog();
            di.Filter = "MP3 Files|*.mp3";
            var rs = di.ShowDialog();
            if ( rs == DialogResult.OK)
            {
                Player.Dispose();
                afr = new AudioFileReader(di.FileName);
                Player.Init(afr);
                Player.Play();
                pictureBox1.Visible = true;
                btn_play.Visible = false;
                btn_stop.Visible = true;
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            Player.Play();
            btn_play.Visible = false;
            btn_stop.Visible = true;
            pictureBox1.Visible = true;

        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            Player.Pause();
            btn_stop.Visible = false;
            btn_play.Visible = true;
            pictureBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var di = new OpenFileDialog();
            di.Multiselect = true;
            di.Filter = "MP3 Files|*.mp3";
            var rs = di.ShowDialog();
            if (rs == DialogResult.OK)
            {
                list = di.FileNames;
                afr = new AudioFileReader(list[0]);
                Player.Init(afr);
                Player.Play();
                pictureBox1.Visible = true;
                btn_play.Visible = false;
                btn_stop.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Player.Dispose();
            i = i + 1;
            afr = new AudioFileReader(list[i]);
            Player.Init(afr);
            Player.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Player.Dispose();
            i = i - 1;
            afr = new AudioFileReader(list[i]);
            Player.Init(afr);
            Player.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try { 
            j = j + 0.1F;
            Player.Volume = j;
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                j = j - 0.1F;
                Player.Volume = j;
            }
            catch { }
        }
    }
}
