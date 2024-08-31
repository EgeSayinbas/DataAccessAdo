using System.Data;
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

                #region sqlden veri okuma
                //cmd.CommandText = "Select * From Shippers";
                //SqlDataReader rdr = cmd.ExecuteReader();
                ////Console.WriteLine("Durum:" + con.State);
                //while (rdr.Read())
                //{
                //    Shipper shipper = new Shipper();
                //    shipper.ShipperId = int.Parse(rdr[0].ToString());
                //    shippers.Add(shipper);

                //    Console.WriteLine(rdr["ShipperId"] + " " + rdr["CompanyName"] + " " + rdr["Phone"]);
                //}
                //shippers.ForEach(Shipper => Console.WriteLine(Shipper.ShipperId));
                #endregion

                #region Crud İslemleri
                //Create=>insert
                //string insertSql= "Insert into Shippers(CompanyName,Phone) values('Yurtici Kargo','444 6677')";
                //string updateSql = "Update Shippers set Phone='444 978 88' where CompanyName='Yurtici Kargo'";
                //string deleteSql = "Delete shippers where CompanyName='Yurtici Kargo'";
                //cmd.CommandText = deleteSql;
                //int sonuc=cmd.ExecuteNonQuery();
                //if(sonuc>0)
                //{
                //    Console.WriteLine("islem basarili");
                //}
                //else
                //{
                //    Console.WriteLine("islem Basarisiz");
                //}
                #endregion

                #region DataSet,DataTable, SqlDataAdapter Kullanimi.

                cmd.CommandText = "Select * From Shippers";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //adapter.InsertCommand.CommandText = "Insert into ...."; //update ve delete icinde bunu yapınca adapter kullanılabilir
                DataSet ds = new DataSet();  // database e karsilik gelen nesnedir burada northwind
                DataTable dt = new DataTable(); //database de tabloya karsılık gelen nesne

                adapter.Fill(ds);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Console.WriteLine(item["ShipperId"] + " " + item["CompanyName"]);

                }
                Console.WriteLine("*************TABLE***************");
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    Console.WriteLine(item["ShipperId"] + " " + item["CompanyName"]);

                }

                #endregion

            }




            catch (SqlException ex)
            {
                Console.WriteLine("Sql hata:" + ex.Message);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Genel hata:" + ex.Message);
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
