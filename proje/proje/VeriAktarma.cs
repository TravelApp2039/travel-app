using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace proje
{
    public class VeriAktarma :VeritabaniBaglantisi
    {
        public DataTable tablo =new DataTable();
        public VeriAktarma()
        {

        }

        public DataTable GetData()
        {
            tablo = base.sqlSutunVerileri();
            return tablo;
        }

        public DataTable GetData(string[] sutunlar)
        {
            tablo = base.ozelVeritabaniVerileri(sutunlar);
            return tablo;
        }

        public DataTable GetData(string sorgu)
        {
            tablo = base.sqlSorguVerileri(sorgu);
            return tablo;
        }

        public void HTMLraporlama()
        {
            try
            {
                string dosyaAdi = null;
                SaveFileDialog htmlKaydet=new SaveFileDialog();
                htmlKaydet.Filter = "HTML files|*.html";
                htmlKaydet.FileName = "HtmlData.html";
                if(htmlKaydet.ShowDialog() == DialogResult.OK)
                {
                    dosyaAdi = htmlKaydet.FileName;
                }

                using(StreamWriter sw = new StreamWriter(dosyaAdi))
                {
                    FileInfo dosyaBilgisi=new FileInfo(dosyaAdi);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendFormat("<!--HTML Raporu | {0}-->",DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                    stringBuilder.Append("<!DOCTYPE html>");
                    stringBuilder.AppendFormat("<html lang='en'>");
                    stringBuilder.AppendFormat("<head>");
                    stringBuilder.AppendFormat("<title>HTML Raporu | {0}</title>", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                    stringBuilder.AppendFormat("</head>");
                    stringBuilder.AppendFormat("<body>");
                    stringBuilder.AppendFormat("<h1>{0}</h1>",dosyaBilgisi.Name.ToUpper());
                    stringBuilder.AppendFormat("<h2> Rapor Bilgileri:</h2>");
                    stringBuilder.AppendFormat("<table>");
                    stringBuilder.AppendFormat("<thead>");
                    stringBuilder.AppendFormat("<tr>");

                    foreach (DataColumn column in tablo.Columns)
                    {
                        stringBuilder.AppendFormat("<th>{0}</th>",column.ColumnName.ToUpper());
                    }

                    stringBuilder.AppendFormat("</tr>");
                    stringBuilder.AppendFormat("</thead>");
                    stringBuilder.AppendFormat("<tbody>");
                    foreach (DataRow row in tablo.Rows)
                    {
                        stringBuilder.AppendFormat("<tr>");
                        for (int i = 0; i < tablo.Columns.Count; i++)
                        {
                            stringBuilder.AppendFormat("<td>{0}</td>",row[i].ToString());
                        }
                        stringBuilder.AppendFormat("</tr>");
                    }
                    stringBuilder.AppendFormat("</tbody>");
                    stringBuilder.AppendFormat("</table>");
                    stringBuilder.AppendFormat("</body>");
                    stringBuilder.AppendFormat("</html>");

                    sw.Write(stringBuilder.ToString());
                }
            }
            catch (Exception i)
            {

                MessageBox.Show(i.Message,"Html hatası ! !");
            }
        }

        public void XMLraporlama()
        {
            try
            {
                string dosyaAdi = null;
                SaveFileDialog xmlKaydet=new SaveFileDialog();
                xmlKaydet.Filter = "XML files |*.xml";
                xmlKaydet.FileName = "XMLData.xml";
                
                if(xmlKaydet.ShowDialog() == DialogResult.OK)
                {
                    dosyaAdi = xmlKaydet.FileName;
                }

                using(StreamWriter sw = new StreamWriter(dosyaAdi))
                {
                    FileInfo dosyaBilgisi=new FileInfo(dosyaAdi);
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<?xml version='1.0' encoding='utf-8'?>");
                    builder.AppendFormat("<!-- XML Raporu | {0} -->",DateTime.Now.ToShortDateString(),DateTime.Now.ToShortTimeString());
                    
                    builder.AppendFormat("<xmlData>");
                    foreach (DataRow dataRow in tablo.Rows)
                    {
                        builder.AppendFormat("<DataRow>");
                        for (int i = 0; i < tablo.Columns.Count; i++)
                        {
                            builder.AppendFormat("<{0}>{1}</{0}>",tablo.Columns[i].ColumnName.ToUpper(),dataRow[i].ToString());
                        }
                        builder.AppendFormat("</DataRow>");
                    }
                    builder.AppendFormat("</xmlData>");
                    sw.WriteLine(builder.ToString());
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message,"XML veri Yükleme Hatası ! !");
            }
        }
    }
}
