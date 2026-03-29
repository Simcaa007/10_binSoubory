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

namespace _05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("..\\..\\sport.txt"))
            using (FileStream fs = new FileStream("..\\..\\sport.dat", FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                while (!sr.EndOfStream)
                {
                    string radek = sr.ReadLine();
                    string[] s = radek.Split(';');

                    bw.Write(int.Parse(s[0]));
                    bw.Write(s[1]);
                    bw.Write(s[2]);
                    bw.Write(char.Parse(s[3]));
                    bw.Write(int.Parse(s[4]));
                    bw.Write(int.Parse(s[5]));
                }
            }

            using (FileStream fs = new FileStream("..\\..\\sport.dat", FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    int osc = br.ReadInt32();
                    string jmeno = br.ReadString();
                    string prijmeni = br.ReadString();
                    char pohlavi = br.ReadChar();
                    int vyska = br.ReadInt32();
                    int hmotnost = br.ReadInt32();

                    textBox1.AppendText($"os. cislo: {osc}, jmeno: {jmeno}, prijmeni: {prijmeni}, " +
                        $"pohlavi: {pohlavi}, vyska: {vyska}, hmotnost: {hmotnost}");
                }
            }
        }
    }
}
