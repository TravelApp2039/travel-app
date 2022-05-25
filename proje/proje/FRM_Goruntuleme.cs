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
    public partial class FRM_Goruntuleme : Form
    {
        public FRM_Goruntuleme()
        {
            InitializeComponent();
        }

        private void FRM_Goruntuleme_Load(object sender, EventArgs e)
        {
            Goruntule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 m = new Form1();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            int ıd = Convert.ToInt32(dataGridView1.Rows[secilialan].Cells[0].Value);
            SeyahatManager sm = new SeyahatManager(new Ucak_Cadir());
                sm.KonakSil(ıd);
                Goruntule();
            konaklama();
        }
        public void konaklama()
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string why = Convert.ToString(dataGridView1.Rows[secilialan].Cells[9].Value);
            int ıd = Convert.ToInt32(dataGridView1.Rows[secilialan].Cells[0].Value);
            string why2 = Convert.ToString(dataGridView1.Rows[secilialan].Cells[8].Value);

            if(why2== "Ulaşım bilgisi iptal edildi")
            {
                MessageBox.Show("Zaten ulaşım bilgisi iptal edilmiş olduğu için Rezervasyonunuz iptal edilmiştir.");
                SeyahatManager sm = new SeyahatManager();
                sm.SeyahatSil(ıd);
                Goruntule();
            }
            else
            {
                if (why == "Konaklama bilgisi iptal edildi")
                {
                    string message = why + " Ulaşım bilgisi de iptal edilsin mi?";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        SeyahatManager sm = new SeyahatManager();
                        sm.SeyahatSil(ıd);
                        Goruntule();

                    }
                    else if (result == DialogResult.No)
                    {
                        // Do nothing  
                    }
                    else
                    {
                        // Do something  
                    }
                }
            }
            
        }
        public void ulasim()
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string why = Convert.ToString(dataGridView1.Rows[secilialan].Cells[8].Value);
            int ıd = Convert.ToInt32(dataGridView1.Rows[secilialan].Cells[0].Value);
            string why2 = Convert.ToString(dataGridView1.Rows[secilialan].Cells[9].Value);
            if (why2 == "Konaklama bilgisi iptal edildi")
            {
                MessageBox.Show("Zaten Konaklama bilgisi iptal edilmiş olduğu için Rezervasyonunuz iptal edilmiştir.");
                SeyahatManager smd = new SeyahatManager();
                smd.SeyahatSil(ıd);
                Goruntule();
            }
            else
            {
                if (why == "Ulaşım bilgisi iptal edildi")
                {
                    string message = why + " konaklama bilgisi de iptal edilsin mi?";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        SeyahatManager sm = new SeyahatManager();
                        sm.SeyahatSil(ıd);
                        Goruntule();

                    }
                    else if (result == DialogResult.No)
                    {
                        // Do nothing  
                    }
                    else
                    {
                        // Do something  
                    }
                }
            }
            
        }
        public void Goruntule()
        {
            SqlConnection sql = new SqlConnection("Data Source = LAPTOP-HSOIO2VO\\SQLEXPRESS; Initial Catalog = YazilimMimari; Integrated Security = TRUE");
            sql.Open();
            SqlDataAdapter d = new SqlDataAdapter("Select * From TBL_Tablo", sql);
            DataSet ds = new DataSet();
            d.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            int ıd = Convert.ToInt32(dataGridView1.Rows[secilialan].Cells[0].Value);
            SeyahatManager sm = new SeyahatManager(new Otobus_Cadir());
            sm.UlasimSil(ıd);
            Goruntule();
            ulasim();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            frmVeriAktarimi frmVeriAktarimi = new frmVeriAktarimi();
            frmVeriAktarimi.Show();
            this.Hide();
        }
    }
}
