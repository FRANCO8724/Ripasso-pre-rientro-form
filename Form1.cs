using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ripasso_pre_rientro
{
    public partial class Form1 : Form
    {

        //Dichiaro il percorso del file e la variabile numerica lunghezza
        public string path = @"../../Arrigoni.csv";
        public int lung = 0;

        Funzioni f;

        public Form1()
        {
            InitializeComponent();
            f = new Funzioni();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f.numcasual();
        }

        
    }
}
