using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json;
namespace proje
{
    public class json
    {
        SqlConnection connect = new SqlConnection("Data Source = LAPTOP-HSOIO2VO\\SQLEXPRESS; Initial Catalog = YazilimMimari; Integrated Security = TRUE");


public void kaydet()
        {
            try
            {

                // Connect to database.
                connect.Open();

            }
            catch (Exception e)
            {

                // Confirm unsuccessful connection and stop program execution.
                MessageBox.Show("Database connection unsuccessful");
                System.Environment.Exit(1);

            }

            // Export path and file.
            string exportPath = @"C:\Users\tuglu";
            string exportJson = "personexport.json";

            // Stream writer for JSON file.
            StreamWriter jsonFile = null;

            // Check to see if the file path exists.
            if (!Directory.Exists(exportPath))
            {

                // Display a message stating file path does not exist.
                Console.WriteLine("File path does not exist.");

                // Stop program execution.
                System.Environment.Exit(1);

            }

            try
            {

                // Query text.
                string sqlText = " SELECT *from TBL_Tablo  ORDER BY Id";





                // Query text incorporated into SQL command.
                SqlCommand sqlSelect = new SqlCommand(sqlText, connect);

                // Execute SQL and place data in a reader object.
                SqlDataReader reader = sqlSelect.ExecuteReader();

                // If data has been returned, do the export.
                if (reader.HasRows)
                {

                    // Stream writer for JSON file.
                    jsonFile = new StreamWriter(@exportPath + exportJson);

                    // Add reader to data table object.
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    // String for JSON.
                    string jsonString = string.Empty;

                    // Wrapper object for JSON.
                    var collectionWrapper = new
                    {

                        person = dataTable

                    };

                    // Convert to JSON.
                    jsonString = JsonConvert.SerializeObject(collectionWrapper,
                                                                Formatting.Indented);

                    // Add JSON to the file.
                    jsonFile.Write(jsonString);

                    // Flush the internal buffer.
                    jsonFile.Flush();

                    // Today's date.
                    DateTime today = DateTime.Now;

                    // Construct the backup file name.
                    string exportBackupJson = exportJson.Substring(0, exportJson.Length - 5) +
                        "-" + (int)today.DayOfWeek + "-" +
                        today.DayOfWeek.ToString().ToLower() + ".json";

                    // Check if the backup file does not exist, or if it does, check that
                    // today's date is different from the last modified date.
                    if (!File.Exists(Path.Combine(exportPath, exportBackupJson)) ||
                        (File.Exists(Path.Combine(exportPath, exportBackupJson)) &&
                        File.GetLastWriteTime(
                            Path.Combine(exportPath, exportBackupJson)).Date !=
                            today.Date))
                    {

                        // Copy the JSON export.
                        File.Copy(Path.Combine(exportPath, exportJson),
                            Path.Combine(exportPath, exportBackupJson), true);

                    }

                }
                else
                {

                    // Message stating no data to export.
                    Console.WriteLine("There is no data to export.");
                    System.Environment.Exit(1);

                }

                // Message stating export successful.
                Console.WriteLine("Data export successful.");

            }
            catch (Exception e)
            {

                // Message stating export unsuccessful.
                Console.WriteLine("Data export unsuccessful.");
                System.Environment.Exit(1);

            }
            finally
            {

                // Close the database connection and JSON file.
                connect.Close();
                jsonFile.Close();

            }

        }

}
}
