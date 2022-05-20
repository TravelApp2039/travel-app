using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true&& radioButton3.Checked == true)
            {
                SeyahatManager sm = new SeyahatManager(new Ucak_Cadir());
                sm.GetAll(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,dateTimePicker1.Text,dateTimePicker2.Text,label7.Text);
                MessageBox.Show("kayit tamamlandi");

            }
            else if (radioButton2.Checked == true && radioButton3.Checked == true) {
                SeyahatManager sm = new SeyahatManager(new Otobus_Cadir());
                sm.GetAll(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, dateTimePicker2.Text, label7.Text);
                MessageBox.Show("kayit tamamlandi");
            }
            else if (radioButton1.Checked == true && radioButton4.Checked == true)
            {
                SeyahatManager sm = new SeyahatManager(new Ucak_Otel());
                sm.GetAll(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, dateTimePicker2.Text, label7.Text);
                MessageBox.Show("kayit tamamlandi");
            }
            else if (radioButton2.Checked == true && radioButton4.Checked == true)
            {
                SeyahatManager sm = new SeyahatManager(new Otobus_otel());
                sm.GetAll(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, dateTimePicker2.Text, label7.Text);
                MessageBox.Show("kayit tamamlandi");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_Goruntuleme m = new FRM_Goruntuleme();
            m.Show();
            this.Hide();
        }
    }
    }
