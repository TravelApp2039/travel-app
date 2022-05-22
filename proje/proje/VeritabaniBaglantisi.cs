using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace proje
{
    public class VeritabaniBaglantisi
    {
        public static string baglantiString { get; set; } 
        public static string tabloAdi { get; set; } 
        protected string baglantiDurumu {get; set;} 
        protected SqlConnection connection { get; set;}
        protected SqlCommand command { get; set; }
        protected SqlDataReader reader { get; set; }


        protected DataTable sqlSutunVerileri()  
        {
            DataTable data = null;
            try
            {
                connection = new SqlConnection(baglantiString);
                string sorgu = string.Format("select * from {0}", tabloAdi);
                using (connection = new SqlConnection(baglantiString))
                {
                    connection.Open();
                    using(command = connection.CreateCommand())
                    {
                        command.CommandText = sorgu;
                        reader = command.ExecuteReader();
                        data=new DataTable();
                        data.Load(reader);
                    }
                }
                return data;
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message,"Veri Yüklenme Hatası !");
                return data;
            }
        } 
        protected DataTable ozelVeritabaniVerileri(string[] sutunAdlari) 
        {
            string sutunlar = "";
            foreach (string sutun in sutunAdlari)
            {
                sutunlar += sutun + ",";
            }
            sutunlar = sutunlar.Remove(sutunlar.LastIndexOf(','), 1);
            DataTable data = null;
            try
            {
                connection = new SqlConnection(baglantiString);
                string sorgu = string.Format("select {0} from {1} ",sutunlar, tabloAdi);
                using (connection = new SqlConnection(baglantiString))
                {
                    connection.Open();
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = sorgu;
                        reader = command.ExecuteReader();
                        data = new DataTable();
                        data.Load(reader);
                    }
                }
                return data;
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message, "Veri Yüklenme Hatası !");
                return data;
            }
        }

        protected DataTable sqlSorguVerileri(string sorgu) 
        {
            DataTable data = null;
            try
            {
                connection = new SqlConnection(baglantiString);
                using (connection = new SqlConnection(baglantiString))
                {
                    connection.Open();
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = sorgu;
                        reader = command.ExecuteReader();
                        data = new DataTable();
                        data.Load(reader);
                    }
                }
                return data;
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message, "Veri Yüklenme Hatası !");
                return data;
            }
        }
    }
}
