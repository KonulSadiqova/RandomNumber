
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RandomNumber
{
    public partial class Form1 : Form
    {
        int num;
        int cehd = 0;
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Left;
            textBox1.RightToLeft = RightToLeft.No;
            YeniOyunBaşlat();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void yenioyunbtn_Click(object sender, EventArgs e)
        {
            YeniOyunBaşlat();
        }

        private void YeniOyunBaşlat()
        {
            num = r.Next(1, 100);
            button1.Enabled = true;
            textBox1.Enabled = true;

            cehd = 0;
            textBox1.Clear();
            richTextBox1.Clear();
            errorProvider1.Clear();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Xana boşdur!");
                return;
            }

            if (!int.TryParse(textBox1.Text.Trim(), out int daxilEdilen))
            {
                errorProvider1.SetError(textBox1, "Zəhmət olmasa düzgün ədəd daxil edin!");
                return;
            }

            errorProvider1.Clear();
            cehd++;

            if (daxilEdilen == num)
            {
                richTextBox1.Text = $"Oyunu qazandınız!\nCəhd sayı: {cehd}";
                button1.Enabled = false;
                textBox1.Enabled = false;
            }
            else if (daxilEdilen > num)
            {
                richTextBox1.Text = $"Siz yanlış tapdınız!\nCəhd sayı: {cehd}\nDaxil etdiyiniz ədəd gizli ədəddən böyükdür.";
            }
            else
            {
                richTextBox1.Text = $"Siz yanlış tapdınız!\nCəhd sayı: {cehd}\nDaxil etdiyiniz ədəd gizli ədəddən kiçikdir.";
            }
        }
    }
}
