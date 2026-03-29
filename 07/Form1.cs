using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("..\\..\\cisla.dat", FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(56);
                bw.Write(7);
                bw.Write(5);
                bw.Write(1);
                bw.Write(13);
                bw.Write(78);
                bw.Write(66);
                bw.Write(9);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool prvocislo = false;
            using (FileStream fs = new FileStream("..\\..\\cisla.dat", FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            using (StreamWriter sw = new StreamWriter("..\\..\\cisla.txt"))
            {
                while (fs.Position < fs.Length)
                {
                    int c = br.ReadInt32();
                    listBox1.Items.Add(c);
                    for (int i = c - 1; i > 1; i--)
                    {
                        if (c % i == 0)
                        {
                            prvocislo = false;
                            break;
                        }
                        prvocislo = true;
                    }
                    if (prvocislo)
                    {
                        sw.WriteLine(c);
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader("..\\..\\cisla.txt"))
            {
                while (!sr.EndOfStream)
                {
                    listBox2.Items.Add(sr.ReadLine());
                }
            }
        }
    }
}
