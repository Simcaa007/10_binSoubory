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

namespace _04
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
                    bw.Write(s);
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
                    listBox1.Items.Add(br.ReadString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = int.Parse(textBox2.Text);
            int l = int.Parse(textBox3.Text);
            using (FileStream fs = new FileStream("..\\..\\cisla.dat", FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                foreach (string s in listBox1.Items)
                {
                    int c = int.Parse(s);
                    if(c == k)
                    {
                        bw.Write(l);
                    }
                    else
                    {
                        bw.Write(c);
                    }
                }
            }

            using (FileStream fs = new FileStream("..\\..\\cisla.dat", FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    listBox2.Items.Add(br.ReadInt32());
                }
            }
        }

        private void k(object sender, EventArgs e)
        {

        }
    }
}
