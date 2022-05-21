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
                sm.GetAll("s","u");
                MessageBox.Show("kayit tamamlandi");

            }
            else if (radioButton2.Checked == true && radioButton3.Checked == true) {
                SeyahatManager sm = new SeyahatManager(new Otobus_Cadir());
                sm.GetAll("s", "u");
                MessageBox.Show("kayit tamamlandi");
            }
            else if (radioButton1.Checked == true && radioButton4.Checked == true)
            {
                SeyahatManager sm = new SeyahatManager(new Ucak_Otel());
                sm.GetAll("s", "u");
                MessageBox.Show("kayit tamamlandi");
            }
            else if (radioButton2.Checked == true && radioButton4.Checked == true)
            {
                SeyahatManager sm = new SeyahatManager(new Otobus_otel());
                sm.GetAll("s", "u");
                MessageBox.Show("kayit tamamlandi");
            }

            SqlConnection sql = new SqlConnection("Data Source=DESKTOP-0QQSKNK\\SQLEXPRESS;Initial Catalog=SOLİD;Integrated Security=True");

                sql.Open();
                SqlCommand komut = new SqlCommand("insert into TBL_Musteri (İsim,Soyisim,TC,[Telefon no]) values (@p1,@p2,@p3,@p4)", sql);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);
                komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.ExecuteNonQuery();
            sql.Close();
            SqlCommand komut2 = new SqlCommand("insert into TBL_RezervasyonBilgi (GidisTarihi,DonusTarhi,Fiyat) values (@p1,@p2,@p3)", sql);
            sql.Open();
            komut2.Parameters.AddWithValue("@p1", dateTimePicker1.Text);
                komut2.Parameters.AddWithValue("@p2", dateTimePicker2.Text);
                komut2.Parameters.AddWithValue("@p3", label7.Text);
                komut2.ExecuteNonQuery();
                sql.Close();
        }

    }
    }
