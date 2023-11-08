using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string DecToHex(int vstup)
        {
            string hex = "";
            while (vstup > 0)
            {
                if (vstup % 16 > 9)
                {
                    hex = (char)((vstup % 16) + 55) + hex;
                }
                else
                {
                    hex = vstup % 16 + hex;
                }
                vstup /= 16;
            }
            return hex;
        }

        public int HexToDec(string vstup)
        {
            int desitkove = 0;
            int cc = 1;
            for(int i = vstup.Length - 1; i >= 0; i--)
            {
                if (vstup[i] >= '0' && vstup[i] <= '9')
                {
                    desitkove += cc * ((int)vstup[i] - 48);
                }
                else if(vstup[i] >= 'A' && vstup[i] <= 'F')
                {
                    desitkove += cc * ((int)vstup[i] - 55);
                }
                else
                {
                    return -1;
                }
                cc *= 16;
            }
            return desitkove;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int vstup = int.Parse(textBox1.Text);
                MessageBox.Show(DecToHex(vstup));
            }
            catch
            {
                MessageBox.Show("Chyba");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vstup = textBox1.Text;
            if(HexToDec(vstup) == - 1)
            {
                MessageBox.Show("Chyba");
            }
            else
            {
                MessageBox.Show(HexToDec(vstup).ToString());
            }
        }
    }
}