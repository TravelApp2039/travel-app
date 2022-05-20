using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace proje
{
    public class SeyahatManager
    {
        private SoyutFabrika _soyutfabrika;
        private Ulasim _ulasim;
        private Konaklama _konaklama;
        public SeyahatManager()
        {

        }
        public SeyahatManager(SoyutFabrika soyutfabrika)
        {
            _soyutfabrika = soyutfabrika;
            _konaklama = _soyutfabrika.konaklamabilgi();
            _ulasim = _soyutfabrika.ulasimbilgi();
        }
        public SeyahatManager(int id)//silme işlemi
        {
            //SqlConnection sql = new SqlConnection("Data Source=DESKTOP-0QQSKNK\\SQLEXPRESS;Initial Catalog=YazilimMimari;Integrated Security=True");
            //sql.Open();
            //SqlCommand komut = new SqlCommand("delete from TBL_Tablo where Id=@p1", sql);
            //komut.Parameters.AddWithValue("@p1", id);
            //komut.ExecuteNonQuery();
            //sql.Close();
        }















        public void ulasimsil(int id)
        {
            string ulasim = _ulasim.ulasiptal();
            SqlConnection sql = new SqlConnection("Data Source=DESKTOP-0QQSKNK\\SQLEXPRESS;Initial Catalog=YazilimMimari;Integrated Security=True");
            sql.Open();
            SqlCommand komut = new SqlCommand("update TBL_Tablo set Ulasim=" + ulasim +" where Id="+id +"", sql);
            komut.ExecuteNonQuery();
            sql.Close();

        }
        public void konaksil(int id)
        {
            string konaklama = _konaklama.Konakiptal();
            SqlConnection sql = new SqlConnection("Data Source=DESKTOP-0QQSKNK\\SQLEXPRESS;Initial Catalog=YazilimMimari;Integrated Security=True");
            sql.Open();
            SqlCommand komut = new SqlCommand("update TBL_Tablo set Konaklama=" + konaklama + " where Id=" + id + "", sql);
            komut.ExecuteNonQuery();
            sql.Close();

        }


















        public void GetAll(string ad,string soyad,string tc,string telefon,string gidis,string donus,string fiyat)
        {
            string ulasim=_ulasim.ulas();
           string konaklam=_konaklama.Konak();
            SqlConnection sql = new SqlConnection("Data Source=DESKTOP-0QQSKNK\\SQLEXPRESS;Initial Catalog=YazilimMimari;Integrated Security=True");
            sql.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_Tablo (Ad,Soyad,Tc,Telefon,GİdisTarihi,DonusTarihi,Fiyat,Ulasim,Konaklama) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", sql);
            komut.Parameters.AddWithValue("@p1", ad);
            komut.Parameters.AddWithValue("@p2", soyad);
            komut.Parameters.AddWithValue("@p3", tc);
            komut.Parameters.AddWithValue("@p4", telefon);
            komut.Parameters.AddWithValue("@p5", gidis);
            komut.Parameters.AddWithValue("@p6", donus);
            komut.Parameters.AddWithValue("@p7", Convert.ToInt32(fiyat));
            komut.Parameters.AddWithValue("@p8", ulasim);
            komut.Parameters.AddWithValue("@p9", konaklam);
            komut.ExecuteNonQuery();
            sql.Close();
        }

    }

    public abstract class Ulasim
    {
        public abstract string ulas();
        public abstract string ulasiptal();

    }
    class ucak : Ulasim
    {
        public override string ulas()
        {
            return "Ucak";
        }
        public override string ulasiptal()
        {
            return "Ucak iptal edildi";
        }
    }
    class otobus : Ulasim
    {
        public override string ulas()
        {
            return "Otobus";

        }
        public override string ulasiptal()
        {
            return "otobus iptal edildi";
        }
    }




    public abstract class Konaklama
    {
        public abstract string Konak();
        public abstract string Konakiptal();
    }
    class Otel : Konaklama
    {
        public override string Konak()
        {
            return "Otel";
        }
        public override string Konakiptal()
        {
            return "Otel iptal edildi";
        }
    }
    class Cadir : Konaklama
    {
        public override string Konak()
        {
            return "Çadır";
        }
        public override string Konakiptal()
        {
            return "Çadır iptal edildi";
        }
    }
}
