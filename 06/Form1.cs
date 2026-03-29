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

namespace _06
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
                foreach (string s in textBox1.Lines)
                {
                    int c = int.Parse(s);
                    bw.Write(c);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("..\\..\\cisla.dat", FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    listBox1.Items.Add(br.ReadInt32());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int min = int.MaxValue;
            long poziceTed = 0;
            long poziceMinima = 0;
            int posledni = 0;
            long pozicePosledni = 0;
            using (FileStream fs = new FileStream("..\\..\\cisla.dat", FileMode.Open, FileAccess.ReadWrite))
            using (BinaryReader br = new BinaryReader(fs)) 
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                while (fs.Position < fs.Length)
                {
                    poziceTed = fs.Position;
                    int c = br.ReadInt32();
                    if (c < min)
                    {
                        min = c;
                        poziceMinima = poziceTed;
                    }
                    else
                    {
                        posledni = c;
                        pozicePosledni = poziceTed;
                    }
                }

                fs.Seek(poziceMinima, SeekOrigin.Begin);
                bw.Write(posledni);

                fs.Seek(pozicePosledni, SeekOrigin.Begin);
                bw.Write(min);

                listBox1.Items.Clear(); 
                fs.Seek(0, SeekOrigin.Begin);

                while (fs.Position < fs.Length)
                {
                    listBox1.Items.Add(br.ReadInt32());
                }
            }
        }
    }
}
