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
            goruntule();
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
            SeyahatManager sm = new SeyahatManager();
            sm.konaksil(ıd);
            goruntule();
            //int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            //int ıd = Convert.ToInt32(dataGridView1.Rows[secilialan].Cells[0].Value);
            //SeyahatManager sm = new SeyahatManager(ıd);
            //goruntule();
            //MessageBox.Show("Silme işlemi tamamlandı");
        }

        public void goruntule()
        {
            SqlConnection sql = new SqlConnection("Data Source=DESKTOP-0QQSKNK\\SQLEXPRESS;Initial Catalog=YazilimMimari;Integrated Security=True");
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
            SeyahatManager sm = new SeyahatManager(ıd);
            sm.ulasimsil(ıd);
            goruntule();
        }
    }
}
