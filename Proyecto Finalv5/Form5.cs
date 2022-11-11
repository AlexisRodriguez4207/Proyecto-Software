using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_Finalv5
{   
    public partial class Form5 : Form 
    {
        bool Play = false;

        public Form5()
        {
            InitializeComponent();
            
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Video.URL = openFileDialog1.FileName;   
        }

        public void ActualizarDTrack()
        {
            if (Video.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                // Tiempo Macimo del Reproductor
                macTrackBarEstatus.Maximum = (int)Video.Ctlcontrols.currentItem.duration;
                tmSlider.Start();
            }
            else if (Video.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                tmSlider.Stop();
            }
            else if (Video.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                tmSlider.Stop();
                macTrackBarEstatus.Value = 0;
            }
        }

        private void macTrackSonido_ValueChanged(object sender, decimal value)
        {
            Video.settings.volume = macTrackSonido.Value;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            switch (Play)
            {
                case true:
                    Video.Ctlcontrols.pause();
                    btnPlay.Image = Properties.Resources.jugar;
                    Play = false;
                    break;

                case false:
                    Video.Ctlcontrols.play();
                    btnPlay.Image = Properties.Resources.pausa; ;
                    Play = true;
                    break;
            }
        }


        private void tmSlider_Tick(object sender, EventArgs e)
        {
            ActualizarDTrack();
            try
            {
                tmSlider.Start();
                macTrackBarEstatus.Value = (int)Video.Ctlcontrols.currentPosition;
                label1.Text = Video.Ctlcontrols.currentPositionString;
                label2.Text = Video.currentMedia.durationString;
            }
            catch
            {
            
            }

        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if((macTrackBarEstatus.Value = macTrackBarEstatus.Value - 15) < 0)
            {
                macTrackBarEstatus.Value = 0;
            }
            else
            {
                macTrackBarEstatus.Value = macTrackBarEstatus.Value - 15;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            macTrackBarEstatus.Value = macTrackBarEstatus.Value + 10;
        }

        private void macTrackBarEstatus_ValueChanged(object sender, decimal value)
        {

        }
    }
}
