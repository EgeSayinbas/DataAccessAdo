using MySqlConnector;

namespace MySqlAdo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string constr = "Server = localhost; Database = sakila; Uid = root; Pwd = z68!t$Fxm9;";
            MySqlConnection conn = new(constr);
            MySqlCommand cmd = conn.CreateCommand();
            conn.Open();
            #region TabloOkuma
            //cmd.CommandText = "Select * From city";

            //MySqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["city"]);
            //}


            #endregion

            #region Tek Deger Okuma
            cmd.CommandText = "Select count(*) Adet from city";
            var sonuc = cmd.ExecuteScalar();
            Console.WriteLine("Kayit Sayisi: "+sonuc);

            #endregion
            
            conn.Close(); 
        }
    }
}
