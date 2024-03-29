﻿using System;
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
            _konaklama = _soyutfabrika.KonaklamaBilgi();
            _ulasim = _soyutfabrika.UlasimBilgi();
        }


        public void SeyahatSil(int id)
        {
            SqlConnection sql = new SqlConnection("Data Source = LAPTOP-HSOIO2VO\\SQLEXPRESS; Initial Catalog =YazilimMimari; Integrated Security = TRUE");
            sql.Open();
            SqlCommand komut = new SqlCommand("delete from TBL_Tablo where Id=@p1", sql);
            komut.Parameters.AddWithValue("@p1", id);
            komut.ExecuteNonQuery();
            sql.Close();
        }



        public void UlasimSil(int id)
        {
            string ulasim = _ulasim.UlasIptal();
            SqlConnection sql = new SqlConnection("Data Source = LAPTOP-HSOIO2VO\\SQLEXPRESS; Initial Catalog =YazilimMimari; Integrated Security = TRUE");
            sql.Open();
            SqlCommand komut = new SqlCommand("update TBL_Tablo set Ulasim=@p1 Where Id=@p2", sql);
            komut.Parameters.AddWithValue("@p1", ulasim);
            komut.Parameters.AddWithValue("@p2", id);
            komut.ExecuteNonQuery();
            sql.Close();

        }
        public void KonakSil(int id)
        {
            string konaklama = _konaklama.Konakiptal();
            SqlConnection sql = new SqlConnection("Data Source = LAPTOP-HSOIO2VO\\SQLEXPRESS; Initial Catalog = YazilimMimari; Integrated Security = TRUE");
            sql.Open();
            SqlCommand komut = new SqlCommand("update TBL_Tablo set Konaklama=@p1 Where Id=@p2", sql);
            komut.Parameters.AddWithValue("@p1", konaklama);
            komut.Parameters.AddWithValue("@p2", id);
            komut.ExecuteNonQuery();
            sql.Close();

        }
       



        public void GetAll(string ad,string soyad,string tc,string telefon,string gidis,string donus,string fiyat)
        {
            string ulasim=_ulasim.Ulas();
            string konaklam=_konaklama.Konak();
            SqlConnection sql = new SqlConnection("Data Source = LAPTOP-HSOIO2VO\\SQLEXPRESS; Initial Catalog = YazilimMimari; Integrated Security = TRUE");
            sql.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_Tablo (Ad,Soyad,Tc,Telefon,GidisTarihi,DonusTarihi,Fiyat,Ulasim,Konaklama) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", sql);
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
        public abstract string Ulas();
        public abstract string UlasIptal();

    }
    class ucak : Ulasim
    {
        public override string Ulas()
        {
            return "Ucak";
        }
        public override string UlasIptal()
        {
            return "Ulaşım bilgisi iptal edildi";
        }
    }
    class otobus : Ulasim
    {
        public override string Ulas()
        {
            return "Otobus";

        }
        public override string UlasIptal()
        {
            return "Ulaşım bilgisi iptal edildi";
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
            return "Konaklama bilgisi iptal edildi";
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
            return "Konaklama bilgisi iptal edildi";
        }
    }
}
