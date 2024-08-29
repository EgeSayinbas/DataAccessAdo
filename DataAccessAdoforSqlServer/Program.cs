using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace DataAccessAdoforSqlServer
{
    internal class Program
    {

        #region Konu Anlatimi

        /*
         * Butun database lerde (sql server, postgresql vb.)
         * Kullanilan bazi Ado.NET classlari vardir
         * 1 - SqlConnection
         * 2 - SqlCommand
         * 3 - SqlDataReader
         * 
         * Ayrica Ado.NET icin tasarlanmis hazir vaziyette gelen
         * dataset ve datatable nesneleride kullanilir
         * 
         * 
         * 
         */

        #endregion
        static void Main(string[] args)
        {
            List<Shipper> shippers = new List<Shipper>();
            #region SqlConnection
            // SqlConnection => bu nesne verilen connectionstring uzerinden veri tabanina baglanir
            // Burada kritik olan yer ConnecitonString cumlesidir
            //ConnectionString leri ogrenmek icin www.connectionstrings.com uzerinden dunyada var olan
            //butun databaselerin connectionstring leri ogrenilebilir 
            string constr = "Server=.; Database = Northwind; Trusted_Connection = True; TrustServerCertificate=True";

            SqlConnection con = new SqlConnection(constr);
            #endregion


            #region SqlCommand => bu nesne illaki SqlConnection nesnesine ihtiyac duyar
            //Tek Basina calismaz.
            //Calistigi zaman gerekli sql scriptler yazilarak sonuc beklenir.
            // diger bir yol SqlCommand cmd2 = con.CreateCommand();


            #endregion


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * From Shippers";
                SqlDataReader rdr = cmd.ExecuteReader();
                //Console.WriteLine("Durum:" + con.State);
                while (rdr.Read())
                {
                    Shipper shipper = new Shipper();
                    shipper.ShipperId = int.Parse(rdr[0].ToString());
                    shippers.Add(shipper);

                    Console.WriteLine(rdr["ShipperId"] + " " + rdr["CompanyName"] + " " + rdr["Phone"]);
                }
                shippers.ForEach(Shipper => Console.WriteLine(Shipper.ShipperId));
            }
            catch (Exception ex)
            {
                Console.WriteLine("hata:" + ex.Message);

            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            Console.WriteLine("Hello, World!");
        }
    }
    public struct Shipper
    {
        public int ShipperId;
        public string CompanyName;
        public string Phone;

    }
    
}
