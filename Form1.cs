using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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

        private void button2_Click(object sender, EventArgs e)
        {
            int a = f.Contacampi();

            listView1.Clear();
            listView1.Items.Add("Ogni record è composto da: " + a + " campi.");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (StreamReader sw = new StreamReader(path))
            {
                int dim = 0;

                string a = sw.ReadLine();

                string[] campi = a.Split(';');

                int[] arr = new int[(campi.Length) + 1];

                for (int i = 0; i < campi.Length; i++)
                {
                    arr[dim] = campi[i].Length;
                    dim++;
                }
                arr[(arr.Length) - 1] = a.Length;

                while (a != null)
                {
                    dim = 0;

                    string[] campi2 = a.Split(';');

                    for (int i = 0; i < campi2.Length; i++)
                    {
                        if (arr[dim] < campi2[i].Length)
                        {
                            arr[dim] = campi2[i].Length;
                        }

                        dim++;
                    }

                    if (arr[(arr.Length) - 1] < a.Length)
                    {
                        arr[(arr.Length) - 1] = a.Length;
                    }

                    a = sw.ReadLine();

                }

                dim = 0;

                listView1.Clear();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != arr.Length - 1)
                    {
                        listView1.Items.Add("Lunghezza campo " + dim.ToString() + ": " + arr[i]);
                    }
                    else
                    {
                        listView1.Items.Add("Lunghezza record " + dim.ToString() + ": " + (arr[arr.Length - 1] + 1));
                    }
                    dim++;
                }

                lung = arr[arr.Length - 1];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lung == 0)
            {
                listView1.Clear();
                listView1.Items.Add("Calcolare prima lunghezza del record più lungo che compone il file");
            }
            else
            {
               f.Lungfissa(lung);
            }

            
        }
    }
}
