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
        public SeyahatManager(SoyutFabrika soyutfabrika)
        {
            _soyutfabrika = soyutfabrika;
            _konaklama = _soyutfabrika.konaklamabilgi();
            _ulasim = _soyutfabrika.ulasimbilgi();
        }
        public void GetAll(string k,string u)
        {
            string ulasim=_ulasim.ulas(k);
           string konaklam=_konaklama.Konak(u);

            SqlConnection sql = new SqlConnection("Data Source=DESKTOP-0QQSKNK\\SQLEXPRESS;Initial Catalog=SOLİD;Integrated Security=True");

            sql.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_Rezervasyon (KonaklamaBilgi,UlasimBilgi) values (@p1,@p2)", sql);
            komut.Parameters.AddWithValue("@p1", ulasim);
            komut.Parameters.AddWithValue("@p2", konaklam);
            komut.ExecuteNonQuery();
            sql.Close();
        }
        public void delete()
        {
            //gelecek
        }
    }

    public abstract class Ulasim
    {
        public abstract string ulas(string message);

    }
    class ucak : Ulasim
    {
        public override string ulas(string message)
        {
            return "Ucak";
        }
    }
    class otobus : Ulasim
    {
        public override string ulas(string message)
        {
            return "Otobus";

        }
    }




    public abstract class Konaklama
    {
        public abstract string Konak(string message);
    }
    class Otel : Konaklama
    {
        public override string Konak(string message)
        {
            return "Otel";
        }
    }
    class Cadir : Konaklama
    {
        public override string Konak(string message)
        {
            return "Çadır";
        }
    }
}
