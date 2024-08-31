using Npgsql;

namespace PostgresAdo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string constr = "Server=127.0.0.1;Port=5432;Database=Northwind;User Id=postgres;Password=z68!t$Fxm9;";
            NpgsqlConnection conn = new(constr);
            conn.Open();
            NpgsqlCommand command = conn.CreateCommand();
            command.CommandText = "Select * From Shippers";
            NpgsqlDataReader reader = command.ExecuteReader();  
            while (reader.Read())
            {
                Console.WriteLine(reader[0] + " " + reader[1]);
            }
            conn.Close();
            Console.WriteLine("Hello, World!");
        }
    }
}
