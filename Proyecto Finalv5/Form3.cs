﻿using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxPg_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://alexisrodriguez4207.github.io/Xeon-Page/");
        }
    }
}
