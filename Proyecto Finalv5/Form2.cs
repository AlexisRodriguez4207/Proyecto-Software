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
    public partial class User : Form
    {
        
        public User()
        {
            InitializeComponent();
            txtUs.Text = "神の呪文#6814";
            txtNom.Text = "Alexis";
            txtNc.Text = "28/09/2001";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Limpiar Usuario
            txtUs.Text = " ";
            txtUs.ReadOnly = false;

            // Limpiar Nombre
            txtNom.Clear();
            txtNom.ReadOnly = false;

            // Limpiar Fecha de Nac
            txtNc.Clear();
            txtNc.ReadOnly = false;

            // Cambiar foto
            pictureBoxUser.Image = System.Drawing.Image.FromFile(@"C:\Users\BALAMRUSH\Downloads\1485477097-avatar_78580.png");
        }

        
    }
}
