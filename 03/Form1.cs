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

namespace _03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("..\\..\\znaky.dat", FileMode.Create, FileAccess.Write))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write('5');
                    bw.Write('z');
                    bw.Write('!');
                    bw.Write('k');
                    bw.Write('Z');
                    bw.Write('-');
                    bw.Write('$');
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Soubor uz existuje");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("..\\..\\znaky.dat", FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    char z = br.ReadChar();
                    listBox1.Items.Add(z);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int poradi = 1;
            char znakPred = '0';
            using (FileStream fs = new FileStream("..\\..\\znaky.dat", FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    poradi++;
                    if (br.ReadChar() == '!')
                    {
                        break;
                    }
                    znakPred = br.ReadChar();
                }
            }
            MessageBox.Show($"prvni vykricnik je na pozici {poradi} a pred nim je znak {znakPred}");
        }
    }
}
