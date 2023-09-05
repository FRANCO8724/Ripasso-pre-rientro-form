using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ripasso_pre_rientro
{
    internal class Funzioni
    {
        public string path = @"../../Arrigoni.csv";

        public void numcasual()
        {
            Random num = new Random();

            string[] arr = new string[1000];
            int dim = 0;

            using (StreamReader sw = new StreamReader(path))
            {
                string a = sw.ReadLine();

                while (a != null)
                {
                    if (dim == 0)
                    {
                        arr[dim] = a + ";miovalore";
                    }
                    else
                    {
                        string b = (num.Next(10, 21)).ToString();
                        arr[dim] = a + ";" + b;
                    }
                    dim++;
                    a = sw.ReadLine();
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                dim = 0;

                while (arr[dim] != null)
                {
                    sw.WriteLine(arr[dim]);
                    dim++;
                }
            }
        }

        public int Contacampi()
        {

            using (StreamReader sw = new StreamReader(path))
            {
                string a = sw.ReadLine();

                string[] campi = a.Split(';');

                int lun = campi.Length;

                return lun;
            }

        }

        public void Lungfissa(int lung)
        {

                int[] cont = new int[1000];

                string[] cont2 = new string[1000];

                int dim = 0;

                using (StreamReader sw = new StreamReader(path))
                {
                    string a;

                    a = sw.ReadLine();

                    while (a != null)
                    {
                        int b = a.Length;

                        cont[dim] = lung - b;

                        cont2[dim] = a;

                        dim++;

                        a = sw.ReadLine();
                    }

                }

                using (StreamWriter sw = new StreamWriter(path))
                {
                    dim = 0;

                    while (cont2[dim] != null)
                    {

                        string a = null;

                        for (int j = 0; j < cont[dim]; j++)
                        {
                            a = a + " ";
                        }

                        sw.WriteLine(cont2[dim] + a);

                        dim++;
                    }
                }
            
        }

        public void Aggrecord(string a1,string a2, string a3, string a4, string a5, string a6, string a7, string a8, string a9, string a10)
        {
            bool[] a = new bool[1000];

            string[] p = new string[1000];

            int dim = 0;

            using (StreamReader sw = new StreamReader(path))
            {
                string b = sw.ReadLine();

                while (b != null)
                {
                    a[dim] = true;

                    p[dim] = b;

                    b = sw.ReadLine();

                    dim++;
                }

                if (b == null)
                {
                    a[dim] = false;
                }

            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                dim = 0;

                while (dim < 1000)
                {

                    if (a[dim] == false)
                    {
                        sw.WriteLine(a1 + ";" + a2 + ";" + a3 + ";" + a4 + ";" + a5 + ";" + a6 + ";" + a7 + ";" + a8 + ";" + a9 + ";" + a10);
                        break;
                    }

                    sw.WriteLine(p[dim]);

                    dim++;
                }
            }
        }

        public string Ricercarec(string a1)
        {
            string a = a1;

            int cont = 0;

            int dim = 0;

            string[] ele = new string[1000];

            using (StreamReader sw = new StreamReader(path))
            {
                string d = sw.ReadLine();

                string[] campi = d.Split(';');

                dim = 0;

                for (int i = 0; i < campi.Length; i++)
                {
                    if ("miovalore" == a)
                    {
                        cont = 11;
                    }
                    else
                    {
                        if (campi[dim] == a)
                        {
                            cont = dim;
                        }
                    }

                    dim++;
                }

                dim = 0;

                while (d != null)
                {
                    string[] campi2 = d.Split(';');

                    ele[dim] = campi2[cont];

                    d = sw.ReadLine();
                    dim++;
                }
            }

            string b = "";

            int t = 0;

            for (int i = 0; i < ele.Length; i++)
            {
                if (ele[i + 1] != null)
                {
                    if (ele[t].Length >= ele[i + 1].Length)
                    {
                        b = ele[t];
                    }
                    else
                    {
                        b = ele[i + 1];
                        t = i + 1;
                    }
                }
                else
                {
                    break;
                }
            }

            return b;
        }

        public void Modifica(string a1, string a2, string a3, string a4, string a5, string a6, string a7, string a8, string a9)
        {
            string a = a1;

            string[] ele = new string[1000];

            int dim = 0;

            int control = 0;

            using (StreamReader sw = new StreamReader(path))
            {
                string b = sw.ReadLine();

                while (b != null)
                {
                    ele[dim] = b;

                    string[] campi = ele[dim].Split(';');

                    for (int i = 0; i < campi.Length; i++)
                    {
                        if (campi[i] == a)
                        {
                            control = dim;
                        }
                    }

                    dim++;

                    b = sw.ReadLine();
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                dim = 0;

                string r = "";

                while (ele[dim] != null)
                {
                    if (dim == control)
                    {
                        string[] campi2 = ele[dim].Split(';');

                        if (a2 != null)
                        {
                            r = r + a2;
                        }
                        else
                        {
                            string[] campi3 = ele[dim].Split(';');
                            r = r + campi3[dim];
                        }

                        if (a3 != null)
                        {
                            r = r + ";" + a3;
                        }
                        else
                        {
                            string[] campi4 = ele[dim].Split(';');
                            r = r + ";" + campi4[dim];
                        }

                        if (a4 != null)
                        {
                            r = r + ";" + a4;
                        }
                        else
                        {
                            string[] campi5 = ele[dim].Split(';');
                            r = r + ";" + campi5[dim];
                        }

                        if (a5 != null)
                        {
                            r = r + ";" + a5;
                        }
                        else
                        {
                            string[] campi6 = ele[dim].Split(';');
                            r = r + ";" + campi6[dim];
                        }

                        if (a6 != null)
                        {
                            r = r + ";" + a6;
                        }
                        else
                        {
                            string[] campi7 = ele[dim].Split(';');
                            r = r + ";" + campi7[dim];
                        }

                        if (a7 != null)
                        {
                            r = r + ";" + a7;
                        }
                        else
                        {
                            string[] campi8 = ele[dim].Split(';');
                            r = r + ";" + campi8[dim];
                        }

                        if (a8 != null)
                        {
                            r = r + ";" + a8;
                        }
                        else
                        {
                            string[] campi9 = ele[dim].Split(';');
                            r = r + ";" + campi9[dim];
                        }

                        if (a9 != null)
                        {
                            r = r + ";" + a9;
                        }
                        else
                        {
                            string[] campi10 = ele[dim].Split(';');
                            r = r + ";" + campi10[dim];
                        }

                        sw.WriteLine(r);
                    }
                    else
                    {
                        sw.WriteLine(ele[dim]);
                    }

                    dim++;
                }
            }
        }

        public void Canclog(string a1)
        {
            bool[] a = new bool[1000];

            string[] a2 = new string[1000];

            string c = a1;

            int dim = 0;

            using (StreamReader sw = new StreamReader(path))
            {
                string b = sw.ReadLine();

                while (b != null)
                {
                    a2[dim] = b;

                    string[] campi = b.Split(';');

                    if (campi[0] == c)
                    {
                        a[dim] = false;
                    }
                    else
                    {
                        a[dim] = true;
                    }
                    dim++;

                    b = sw.ReadLine();
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                dim = 0;

                while (a2[dim] != null)
                {

                    if (a[dim] == true)
                    {
                        sw.WriteLine(a2[dim]);
                    }
                    dim++;
                }
            }
        }

    }
}