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
        int vl = 50;
        public OpenFileDialog archivo = new OpenFileDialog();
        bool Play = false;
        int Rep = 0;
        

        public Form5()
        {
            InitializeComponent();
            //panel2.Visible = false;

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            //if (Video.currentMedia == null)
            //{
            //    DialogResult Sl = MessageBox.Show("Necesitas seleccionar mínimo Una Canción \nVuelve a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tmSlider.Stop();
            //}
            //openFileDialog1.ShowDialog();
            //Video.URL = openFileDialog1.FileName;
            try
            {           
                    AbrirArchivo();
                    if (ruta != "")
                    {
                        Rep = 2;
                        AbrirMusic();
                    }
                    else
                    {

                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el archivo");
            }
        }

        public void ActualizarDTrack()
        {
            if (Video.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                // Tiempo Maximo del Reproductor
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
            label4.Text = Video.settings.volume.ToString();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (Rep == 1)
            {
                AbrirMusic();
                Rep = 2;
            }
            else if (Rep == 2)
            {
                Video.Ctlcontrols.pause();
                tmSlider.Stop();
                btnPlay.Image = Properties.Resources.jugar;
                Rep = 3;
            }
            else if (Rep == 3)
            {
                Video.Ctlcontrols.play();
                tmSlider.Start();
                btnPlay.Image = Properties.Resources.pausa;
                Rep = 2;
            }
        }

        string ruta;
        public void AbrirMusic()
        {
            try
            {
                if (Video.currentMedia != null)
                {
                    Video.Ctlcontrols.stop();
                    Video.URL = "";
                }
                else
                {
                    Video.URL = @"" + ruta;
                    Video.Ctlcontrols.play();

                    this.Visible = true;
                    tmSlider.Start();
                    macTrackBarEstatus.Enabled = true;
                    btnPlay.Image = Properties.Resources.pausa;
                }
            }
            catch
            {
                MessageBox.Show("No se pudo abrir el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void macTrackBarEstatus_ValueChanged(object sender, decimal value)
        {
            macTrackBarEstatus.Maximum = (int)Video.currentMedia.duration;
            if (macTrackBarEstatus.Value == (int)Video.Ctlcontrols.currentPosition)
            {
                // Prueba
                //Video.Ctlcontrols.currentPosition = macTrackBarEstatus.Value;
            }
            else
            {
                Video.Ctlcontrols.currentPosition = macTrackBarEstatus.Value;
            }
        }

        private void tmSlider_Tick(object sender, EventArgs e)
        {
            //if (Video.currentMedia == null)
            //{
            //    DialogResult Sl = MessageBox.Show("Necesitas seleccionar mínimo Una Canción \nVuelve a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tmSlider.Stop();
            //}
           
                try
                {
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

        //Abrir Archivos
        public void AbrirArchivo()
        {
            archivo.Filter = "Archivos de Video (*.mp4)|*.mp4|Archivos de Audio (*.mp3)|*.mp3";
            DialogResult dres = archivo.ShowDialog();
            if (dres == DialogResult.Abort)
                return;
            if (dres == DialogResult.Cancel)
                return;
            ruta = archivo.FileName;
            label3.Text = archivo.SafeFileName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            macTrackBarEstatus.Value = macTrackBarEstatus.Value + 10;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label4.Text = (macTrackSonido.Value = Video.settings.volume = vl).ToString();
            this.Video.uiMode = "none";
        }

        private void Video_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
