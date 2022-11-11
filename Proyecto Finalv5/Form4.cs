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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            txtUs.Text = "神の呪文#6814";
            txtNom.Text = "Alexis Rodriguez";
            txtFN.Text = "28/09/2001";
            txtCon.Text = "Contraseña1";
            txtCorr.Text = "XeonMusic@gmail.com";
            txtMP.Text = "Tarjeta de Credito";
            txtSus.Text = "Mensual";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
