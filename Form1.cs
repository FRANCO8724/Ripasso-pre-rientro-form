﻿using System;
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
                listView1.Clear();
                f.Lungfissa(lung);
                listView1.Items.Add("Tutti i record hanno la stessa lòunghezza");
            }

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            f.Aggrecord(textBox1.Text,textBox9.Text ,textBox10.Text,textBox11.Text ,textBox12.Text ,textBox18.Text , textBox13.Text , textBox15.Text , textBox14.Text ,textBox17.Text);
            textBox1.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox18.Text = "";
            textBox13.Text = "";
            textBox15.Text = "";
            textBox14.Text = "";
            textBox17.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string a = textBox2.Text;
            string b = textBox3.Text;
            string c = textBox4.Text;

            int a1 = 0;
            int b1 = 0;
            int c1 = 0;

            bool a2 = false;
            bool b2 = false;
            bool c2 = false;

            using (StreamReader sw = new StreamReader(path))
            {
                string d = sw.ReadLine();

                string[] campi = d.Split(';');

                int dim = 0;

                for (int i = 0; i < campi.Length; i++)
                {
                    if (a == "miovalore")
                    {
                        a1 = 10;
                    }
                    else
                    {
                        if (a == "")
                        {
                            a2 = true;
                        }
                        else
                        {
                            if (campi[dim] == a)
                            {
                                a1 = dim;
                            }
                        }
                    }

                    if (b == "miovalore")
                    {
                        b1 = 10;
                    }
                    else
                    {
                        if (b == "")
                        {
                            b2 = true;
                        }
                        else
                        {
                            if (campi[dim] == b)
                            {
                                b1 = dim;
                            }
                        }
                    }

                    if (c == "miovalore")
                    {
                        c1 = 10;
                    }
                    else
                    {
                        if (c == "")
                        {
                            c2 = true;
                        }
                        else
                        {
                            if (campi[dim] == c)
                            {
                                c1 = dim;
                            }
                        }
                    }

                    dim++;
                }

                listView1.Clear();

                while (d != null)
                {

                    string[] campi2 = d.Split(';');

                    if (a2 == true)
                    {
                        listView1.Items.Add("Campo 1:");
                    }
                    else
                    {
                        listView1.Items.Add("Campo 1:" + campi2[a1]);
                    }

                    if (b2 == true)
                    {
                        listView1.Items.Add("Campo 2:");
                    }
                    else
                    {
                        listView1.Items.Add("Campo 2:" + campi2[b1]);
                    }

                    if (c2 == true)
                    {
                        listView1.Items.Add("Campo 3:");
                    }
                    else
                    {
                        listView1.Items.Add("Campo 3:" + campi2[c1]);
                    }

                    listView1.Items.Add("");

                    d = sw.ReadLine();
                }

            }

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string b = f.Ricercarec(textBox5.Text);

            listView1.Clear();
            listView1.Items.Add("Parola più lunga all'interno del campo " + textBox5.Text + " :");
            listView1.Items.Add(b);

            textBox5.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            f.Modifica();
            textBox6.Text = "";
        }
    }
}
