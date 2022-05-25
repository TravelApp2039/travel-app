using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{
    public partial class frmVeriAktarimi : Form
    {
        public frmVeriAktarimi()
        {
            InitializeComponent();
        }

        private string baglantiString = null;
        private string tabloAdi = null;

        VeriAktarma aktarma = null;

        private void frmVeriAktarimi_Load(object sender, EventArgs e)
        {
            baglantiString = "Data Source=LAPTOP-HSOIO2VO\\SQLEXPRESS;Initial Catalog=YazilimMimari;Integrated Security=TRUE";
            tabloAdi = "TBL_Tablo";
            aktarma = new VeriAktarma();
            VeritabaniBaglantisi.baglantiString=baglantiString;
            VeritabaniBaglantisi.tabloAdi=tabloAdi;
            dataGridView1.DataSource = aktarma.GetData(new string[] {"Ad","Soyad","Tc","GidisTarihi","DonusTarihi","Fiyat","Ulasim","Konaklama"});
        }

        private void linklblHTML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            aktarma.HTMLraporlama();
        }

        private void linklblXML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            aktarma.XMLraporlama();
        }

        private void linklblJSON_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            json js = new json();
            js.kaydet();
        }
    }
}
