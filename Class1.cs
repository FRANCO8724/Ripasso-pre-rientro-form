using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

       
    }
}