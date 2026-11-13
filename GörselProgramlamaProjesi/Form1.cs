using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GörselProgramlamaProjesi
{
    public partial class Form1 : Form
    {
        int sure;
        int para;
        Random rnd = new Random();
        ArrayList kullanıcılar = new ArrayList();
        ArrayList paralar = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        void listele()
        {
            listBox1.Items.Clear();
            comboBox1.Items.Clear();

            for (int i = 0; i < kullanıcılar.Count; i++)
            {
                listBox1.Items.Add(kullanıcılar[i] + " - " + paralar[i] + "₺");
                comboBox1.Items.Add(kullanıcılar[i] + " - " + paralar[i] + "₺");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnOyun.Visible = false;
            lblSure.Text = "Süre: -";
            lblPuan.Text = "Para: 0";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtKullanici.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen kullanıcı adı giriniz!");
                return;
            }
           
            sure = 10;
            para = 0;

            lblSure.Text = "Süre: " + sure;
            lblPuan.Text = "Para: " + para;

            btnOyun.Visible = true;
            timer1.Start();
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sure--;
            lblSure.Text = "Süre: " + sure;

            if (sure <= 0)
            {
                timer1.Stop();
                btnOyun.Visible = false;
                paralar.Add(para);
                kullanıcılar.Add(txtKullanici.Text);
                listele();

                MessageBox.Show("Süre doldu!");
                lblPuan.Text = "Para: 0";
                txtKullanici.Text = "";
            }
        }

        private void btnOyun_Click(object sender, EventArgs e)
        {
            para += 20;
            lblPuan.Text = "Para: " + para;

            int maxX = panelOyun.Width - btnOyun.Width;
            int maxY = panelOyun.Height - btnOyun.Height;

            int x = rnd.Next(0, maxX);
            int y = rnd.Next(0, maxY);

            btnOyun.Location = new Point(x, y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) groupBox2.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) groupBox2.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) groupBox2.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                groupBox3.Enabled = true;
                numericUpDown1.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                groupBox3.Enabled = true;
                numericUpDown1.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                groupBox3.Enabled = true;
                numericUpDown1.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult tus = MessageBox.Show("İşlemi Onaylıyor Musunuz?", "YBS BURGER", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Kullanıcı seçiniz");
                
            }
            else if (tus == DialogResult.Yes)
            {
                double toplam = 0;

                
                if (radioButton1.Checked) toplam += 20;
                else if (radioButton2.Checked) toplam += 40;
                else if (radioButton3.Checked) toplam += 75;

             
                if (radioButton5.Checked) toplam += 10;
                else if (radioButton6.Checked) toplam += 15;

               
                if (checkBox1.Checked) toplam += 25;
                if (checkBox2.Checked) toplam += 10;
                if (checkBox3.Checked) toplam += 8;
                if (checkBox4.Checked) toplam += 7;
                if (checkBox5.Checked) toplam += 12;
               
                toplam *= Convert.ToInt32(numericUpDown1.Value);


                MessageBox.Show("Toplam Sipariş Tutarı = " + toplam + " ₺");

                int seckullanici = comboBox1.SelectedIndex;
                int secpara = Convert.ToInt32(paralar[seckullanici]);

                if (secpara >= toplam)
                {
                    paralar[seckullanici] = secpara - toplam;
                        listele();
                    MessageBox.Show("ödeme başarılı");
                }
                else
                {
                    MessageBox.Show("Yeterli paranız yok.");
                }
                

            }
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            numericUpDown1.Enabled = false;
            button1.Enabled = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            comboBox1.Text = "";

            numericUpDown1.Value = 1;
        }

        private void txtKullanici_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSure_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
