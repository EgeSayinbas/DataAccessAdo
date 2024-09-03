using Microsoft.Data.Sqlite;

namespace SQLiteSample
{
    internal class Program
    {

        public static string constr = "Data Source=c:\\tempdata\\Test.db";
        //using var connection = new SqliteConnection("Data Source=C:\\tempdata\\Test.db");
    static void Main(string[] args)
        {
            SqliteConnection connection = new SqliteConnection(constr);

            try
            {
                connection.Open();
                string sql = "Select * From Kategoriler";
                SqliteCommand command = connection.CreateCommand(); 
                command.CommandText = sql;
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " +reader[1] + " bitti" );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
