using Kontakty.KontaktyKlasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kontakty
{
    public partial class Form1 : Form
    {
        KontaktyKlasa c = new KontaktyKlasa();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Imie = textBox1.Text;
            c.Nazwisko= textBox2.Text;
            c.Telefon = textBox3.Text;
            c.AdresMailowy = textBox4.Text;
            c.AdresZamieszkania = textBox5.Text;

     
            bool success = c.Insert(c);
            if(success==true)
            {
                MessageBox.Show("Nowy kontakt dodany");
            }
            else
            {
                MessageBox.Show("Nie udało się dodać kontaktu");
            }


        }
    }
}
