using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Parametr_El_Gamal_homomorph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = true;
            groupBox1.Visible = true;
            groupBox2.Hide();
            groupBox4.Hide();
            groupBox3.Hide();
        }
        
        public int q = 0, x = 0, R = 0, a = 0; BigInteger y = 0, C11 = 0, C12 = 0,
        C21 = 0, C22 = 0, C1 = 0, C2 = 0; int k3, k2 = 0; int R1, R2 = 0; BigInteger M1 = 0, M2 = 0;
       // Asosiy algoritm jarayoni
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
        // kalitlarni hosil qilish
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox1.Visible = true;
            groupBox2.Hide();
            groupBox4.Hide();
            button1.FlatStyle = FlatStyle.Flat;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label37.Text = "";
            label38.Text = "";
            button6.Enabled = true;
            // q modulni generatsiya qilish;
            Crypto cs = new Crypto();
            q = cs.GenPrime();
            textBox1.Text = q.ToString();

            // x maxfiy kalitni generatsiya qilish
            Random rn = new Random();
            x = rn.Next(1, 29999999);
            textBox2.Text = x.ToString();


            // Modul q dan kichik va x bilan o'zaro tub bo'lgan R ni hosil qilish
            R = 0; int k = 0;
            while (k != 1)
            {
                Random rn1 = new Random();
                R = rn1.Next(1, 1000000);
                k = cs.EKUB(x, R);
            }
          
            textBox3.Text = R.ToString();

            // Primitiv a soni tanlab olinadi
            BigInteger k1 = 0; a = 0;
            do
            {
                a = rn.Next(1, 1000000);
                k1 = BigInteger.ModPow(a, q - 1, q);
            }
            while (k1 != 1);
            textBox4.Text = a.ToString();


            // y kalitni hisoblash;
            y = cs.diadaraja(R, q, a, x);
            textBox5.Text = y.ToString();
            label37.Text = "ochiq kalitlar: q=" + q + "  a=" + a + "  y=" + y;
            label38.Text = "yopiq kalitlar: x=" + x + "  R=" + R;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox2.Visible = true;
            groupBox1.Hide();
            groupBox4.Hide();
            groupBox3.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (textBox7.Text == ""||textBox12.Text=="")
            {
                MessageBox.Show("Xabar kiritilmagan");
            }
            else
            {
                // M xabarni kiritish
                M1 = int.Parse(textBox7.Text);
                M2 = int.Parse(textBox12.Text);
                // Modul q dan kichik va x bilan o'zaro tub bo'lgan k ni hosil qilish
                
                Crypto cs = new Crypto();
                while (k3 != 1)
                {
                    Random rn1 = new Random();
                    R1 = rn1.Next(1, 1000000);
                    k3 = cs.EKUB(x, R1);
                    textBox6.Text = R1.ToString();
                }
               
                while (k2 != 1)
                {
                    Random rn2 = new Random();
                    R2 = rn2.Next(1, 1000000);
                    k2 = cs.EKUB(x, R2);
                    textBox26.Text = R2.ToString();
                }
                
                

            }

            Crypto f1 = new Crypto();
            C11 = f1.diadaraja(R, q, a, R1);
            C12 = M1 * f1.diadaraja(R, q, y, R2);
            textBox8.Text = C11.ToString();
            textBox9.Text = C12.ToString();
            C21 = f1.diadaraja(R, q, a, k2);
            C22 = M2 * f1.diadaraja(R, q, y, k2);
            textBox10.Text = C21.ToString();
            textBox11.Text = C22.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            groupBox3.Visible = true;
            groupBox1.Hide();
            groupBox4.Hide();
            groupBox2.Hide();
            textBox13.Text = C11.ToString();
            textBox14.Text = C12.ToString();
            textBox15.Text = C21.ToString();
            textBox16.Text = C22.ToString();
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Crypto f1 = new Crypto();
            C2 = (C12 * C22) % q;
            textBox17.Text = C1.ToString();
            textBox18.Text = C2.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
            groupBox4.Visible = true;
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            textBox21.Text = x.ToString();
            textBox22.Text = R.ToString();
            textBox19.Text = C1.ToString();
            textBox20.Text = C2.ToString();
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Crypto cs2 = new Crypto();
            BigInteger k1 = cs2.diadaraja(R, q, C11, x);
            BigInteger k2 = cs2.diadaraja(R, q, C21, x);
            BigInteger kt1 = cs2.teskari(q, k1);
            BigInteger kt2 = cs2.teskari(q, k2);
            BigInteger M = (C2 * kt1*kt2) % q;
            while (M < 0)
            {
                M = M + q;
            }
            
            textBox23.Text = M.ToString();
            textBox24.Text = textBox7.Text;
            textBox25.Text = textBox12.Text;
            textBox27.Text = Convert.ToString(M1 * M2);
            
        }

       
    }
}
