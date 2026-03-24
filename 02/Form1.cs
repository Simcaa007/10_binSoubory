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

namespace _02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open("..\\..\\cisla.dat", FileMode.Create)))
            {
                bw.Write(2);
                bw.Write(10);
                bw.Write(25);
                bw.Write(6);
                bw.Write(7);
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        int cislo = br.ReadInt32();
                        listBox1.Items.Add(cislo);
                    }
                }
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (int c in listBox1.Items)
                    {
                        sw.WriteLine(c);
                    }
                }
            }
        }
    }
}
