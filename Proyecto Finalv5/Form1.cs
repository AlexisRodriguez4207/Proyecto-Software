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
    public partial class Form1 : Form
    {
        // Variables
        string[] Archivos;
        string[] ArchivosMP3;
        int vl = 50;
        int Rep = 0;

        public Form1()
        {
            InitializeComponent();
            // Llamada al metodo
            PersDis();
            panel2.Visible = true;
        }
        // Variables
        bool Play = false;
        public bool ModeColor = true;


        // Quitar los Submenus
        private void PersDis()
        {
            panelMedia.Visible = false;
            panelSubX.Visible = false;
            panelSubMP.Visible = false;
        }

        // Ocultar el Munu Princ
        public void OcultarMenu()
        {
            // Primer Menu
            if (panelMedia.Visible == true)
            {
                panelMedia.Visible = false;
            }
            // Segundo
            if (panelSubMP.Visible == true)
            {
                panelSubMP.Visible = false;
            }

            // Tercero
            if (panelSubX.Visible == true)
            {
                panelSubX.Visible = false;
            }
        }

        string ruta;
        public void AbrirMusic()
        {
            try
            {
                Reproductor.URL = @"" + ruta;
                Reproductor.Ctlcontrols.play();

                this.Visible = true;
                timer1.Start();
                macTrackBarEstatus.Enabled = true;
                btnPlay.Image = Properties.Resources.pausa;
            }
            catch
            {
                MessageBox.Show("No se pudo abrir el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Mostrar los Menus
        private void MostrarMenus(Panel SubMenu)
        {
            // Condicion para saber si el submenu esta oculto 
            if (SubMenu.Visible == false)
            {
                OcultarMenu();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }

        private void btnSg_Click(object sender, EventArgs e)
        {
            MostrarMenus(panelMedia);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OcultarMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OcultarMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OcultarMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OcultarMenu();
        }

        // Playlist
        private void btnPlayL_Click(object sender, EventArgs e)
        {
            MostrarMenus(panelSubMP);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
             // Agregar Canciones
            OpenFileDialog BuscarArc = new OpenFileDialog();
            BuscarArc.Multiselect = true;

            if (BuscarArc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Archivos = BuscarArc.SafeFileNames;
                ArchivosMP3 = BuscarArc.FileNames;
                foreach (var Archivos in ArchivosMP3)
                {
                    lstCan.Items.Add(Archivos);
                }
            }
            Reproductor.URL = ArchivosMP3[0];
            lstCan.SelectedIndex = 0;
            OcultarMenu();
        }

        private Form FormActual = null;
        // Metodo para abrir un panel
        private void AbrirPanelC(Form Formb)
        {
            // Condicion para cerrar si el formulario es distinto de null
            if (FormActual != null)
            {
                FormActual.Close();
            }
            FormActual = Formb;
            Formb.TopLevel = false;
            Formb.FormBorderStyle = FormBorderStyle.None;
            Formb.Dock = DockStyle.Fill;

            // Formulario Agregar Controles
            panelCentro.Controls.Add(Formb);
            panelCentro.Tag = Formb;

            //Traer el formulario al frente
            Formb.BringToFront();
            // Mostrar
            Formb.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Lista            
            lstCan.Visible = true;
            lstCan.Items.Clear();
            timer1.Stop();
            Reproductor.close();
            lblCancion.Text = " ";
            lstCan.Visible = false;
            OcultarMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MostrarMenus(panelSubX);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AbrirPanelC(new User());
            OcultarMenu();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Salida del programa
            DialogResult Sl = MessageBox.Show("¿Seguro que quieres cerrar el Programa? ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Sl == DialogResult.No)
            {
                lblCancion.Focus();
            }
            else
            {
                Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Agregar Canciones
            
            OpenFileDialog BuscarArc = new OpenFileDialog();
            BuscarArc.Multiselect = true;
            BuscarArc.Filter = "Archivos de Audio (*.mp3)|*.mp3|Archivos de Video (*.mp4)|*.mp4";
            DialogResult des = BuscarArc.ShowDialog();
            if (des == DialogResult.Abort)
                return;
            if (des == DialogResult.Cancel)
                return;

            //if (BuscarArc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            Archivos = BuscarArc.SafeFileNames;
            ArchivosMP3 = BuscarArc.FileNames;
            foreach (var Archivos in ArchivosMP3)
            {
                timer1.Start();
                lstCan.Items.Add(Archivos);
            }
            //}

            //public OpenFileDialog archivo = new OpenFileDialog();
            //archivo.Filter = "Archivos de Video (*.mp4)|*.mp4|Archivos de Audio (*.mp3)|*.mp3";
            //DialogResult dres = archivo.ShowDialog();
            //if (dres == DialogResult.Abort)
            //    return;
            //if (dres == DialogResult.Cancel)
            //    return;

            if (lstCan.Items.Count > 0)
            {
                Reproductor.URL = ArchivosMP3[0];
                lstCan.SelectedIndex = 0;
            }
            else {
                // Salida del programa
                DialogResult Sl = MessageBox.Show("Necesitas seleccionar mínimo Una Canción vuelve abrir el programa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (Sl == DialogResult.OK)
                {
                    Close();
                }
            }

            //Reproductor.URL = ArchivosMP3[0];
            //lstCan.SelectedIndex = 0;
            
            


        }

        private void lstCan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reproductor.URL = ArchivosMP3[lstCan.SelectedIndex];
            //lblCancion.Text = ArchivosMP3[lstCan.SelectedIndex];
            lblCancion.Text = lstCan.SelectedItem.ToString();
            lblCancion.Visible = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            switch (Play)
            {
                case true:
                    Reproductor.Ctlcontrols.pause();
                    btnPlay.Image = Properties.Resources.jugar;
                    Play = false;
                    
                    break;

                case false:
                    Reproductor.Ctlcontrols.play();
                    btnPlay.Image = Properties.Resources.pausa; ;
                    Play = true;

                    break;
            }

            //if (Rep == 1)
            //{
            //    AbrirMusic();
            //    Rep = 2;
            //}
            //else if (Rep == 2)
            //{
            //    Reproductor.Ctlcontrols.pause();
            //    timer1.Stop();
            //    btnPlay.Image = Properties.Resources.jugar;
            //    Rep = 3;
            //}
            //else if (Rep == 3)
            //{
            //    Reproductor.Ctlcontrols.play();
            //    timer1.Start();
            //    btnPlay.Image = Properties.Resources.pausa;
            //    Rep = 2;
            //}
        }

        private void macTrackSonido_ValueChanged(object sender, decimal value)
        {
            Reproductor.settings.volume = macTrackSonido.Value;
            lblVol.Text = Reproductor.settings.volume.ToString();
        }

        public void ActualizarDTrack()
        {
            //if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPlaying)
            //{
            //    // Tiempo Macimo del Reproductor
            //    macTrackBarEstatus.Maximum = (int)Reproductor.Ctlcontrols.currentItem.duration;
            //    timer1.Start();
            //}
            //else if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPaused)
            //{
            //    timer1.Stop();
            //}
            //else if (Reproductor.playState == WMPLib.WMPPlayState.wmppsStopped)
            //{
            //    timer1.Stop();
            //    macTrackBarEstatus.Value = 0;
            //}

            
            
                if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    // Tiempo Maximo del Reproductor
                    macTrackBarEstatus.Maximum = (int)Reproductor.Ctlcontrols.currentItem.duration;
                    timer1.Start();
                }
                else if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPaused)
                {
                    timer1.Stop();
                }
                else if (Reproductor.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    timer1.Stop();
                    macTrackBarEstatus.Value = 0;
                }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ActualizarDTrack();
            macTrackBarEstatus.Value = (int)Reproductor.Ctlcontrols.currentPosition;
            macTrackSonido.Value = Reproductor.settings.volume;
            try
            {
                macTrackBarEstatus.Value = (int)Reproductor.Ctlcontrols.currentPosition;
                lblIn.Text = Reproductor.Ctlcontrols.currentPositionString;
                //lblFin.Text = Reproductor.currentMedia.durationString;

            }
            catch
            {

            }

        }

        private void Reproductor_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            ActualizarDTrack();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (lstCan.Items.Count == 1)
            {
                Reproductor.Ctlcontrols.play();
            }
            if (lstCan.Items.Count == 0) { 
                DialogResult Sl = MessageBox.Show("Necesitas seleccionar mínimo Una Canción \nVuelve a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (lstCan.SelectedIndex == 0)
                {
                    lstCan.SelectedIndex = lstCan.Items.Count - 1;
                }
                else
                {
                    lstCan.SelectedIndex = lstCan.SelectedIndex - 1;
                }
            }
                //Reproductor.URL = ArchivosMP3[1];
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {    
            if (lstCan.Items.Count < 0)
            {
                DialogResult Sl = MessageBox.Show("Necesitas seleccionar mínimo Una Canción \nVuelve a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (lstCan.Items.Count <= 0)
            {
                DialogResult Sl = MessageBox.Show("Necesitas seleccionar mínimo Una Canción \nVuelve a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Reproductor.Ctlcontrols.play();
                Reproductor.URL = ArchivosMP3[0];
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (lstCan.Items.Count <= 0)
            {
                DialogResult Sl = MessageBox.Show("Necesitas seleccionar mínimo Una Canción \nVuelve a intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Random aleatorio = new Random();
                Reproductor.URL = ArchivosMP3[aleatorio.Next(2)];
            }
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lstCan.Visible = true;
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AbrirPanelC(new Form3());
            OcultarMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AbrirPanelC(new Form4());
            OcultarMenu();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AbrirPanelC(new Form5());
            //panel2.Visible = false;
            OcultarMenu();
        }

        private void btnLm_Click(object sender, EventArgs e)
        {
            switch (ModeColor)
            {
                case true:
                    btnLm.Image = Properties.Resources.moon_dark_mode_night_mode_icon_190939;
                    ModeColor = false;
                    panelCentro.BackColor = Color.FromArgb(192, 192, 255);
                    panel2.BackColor = Color.FromArgb(192, 192, 255);
                    label3.ForeColor = Color.Black;
                    label4.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    lblCancion.ForeColor = Color.Black;
                    pictureBox5.Image = Properties.Resources.Log;
                    //panelLg.BackColor = Color.FromArgb(108, 94, 110);



                    break;

                case false:
                    btnLm.Image = Properties.Resources.sun_icon_icons_com_48221;
                    ModeColor = true;
                    panelCentro.BackColor = Color.FromArgb(108, 94, 110);
                    panel2.BackColor = Color.FromArgb(108, 94, 110);
                    label3.ForeColor = Color.White;
                    label4.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                    lblCancion.ForeColor = Color.White;
                    label1.ForeColor = Color.White;

                    //panelLg.BackColor = Color.FromArgb(192, 192, 255);

                    break;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void macTrackBarEstatus_ValueChanged(object sender, decimal value)
        {
            macTrackBarEstatus.Maximum = (int)Reproductor.currentMedia.duration;
            if (macTrackBarEstatus.Value == (int)Reproductor.Ctlcontrols.currentPosition)
            {
                // Prueba
                //Video.Ctlcontrols.currentPosition = macTrackBarEstatus.Value;
            }
            else
            {
                Reproductor.Ctlcontrols.currentPosition = macTrackBarEstatus.Value;
            }

        }

        private void panelMedia_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblVol.Text = (macTrackSonido.Value = Reproductor.settings.volume = vl).ToString();
            this.Reproductor.uiMode = "none";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            AbrirPanelC(new Form1());
            OcultarMenu();
            panelSubMP.Visible = false;
            panelLg.Visible = false;
            panelMedia.Visible = false;
            panelSubX.Visible = false;

            //
            btnSg.Visible = false;
            btnPlayL.Visible = false;
            button10.Visible = false;
            btnAyuda.Visible = false;
            button2.Visible = false;
        }
    }
}
