using System;
using MySql.Data.MySqlClient;

namespace CaixaDeMercado
{
    public class Db
    {
        static string connectionString = "server=localhost; user=root; database=tecshop; port=3306; password=";
        
        static MySqlConnection connection = new MySqlConnection(connectionString);
        static MySqlCommand? command; 
        static MySqlDataReader? reader;
        //static MySqlDataAdapter? adapter;

        public void closesql()
        {
            try
            {
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " +ex.Message.ToString());   
            }
        }
        private string addProduct = "insert into product (BarCode, Name, Price, Stock) values (@barcode,@name,@price,@stock)";

        public void insertProduct(int barCode, string name, double price, int stock)
        {
            try
            {
                command = new MySqlCommand(addProduct,connection);
                command.Parameters.AddWithValue("@barcode", barCode);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@stock", stock);

                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " +ex.Message.ToString());   
            }
            finally
            {
                connection.Close();
            }
        }

        private string checkProduct = "select * from product where BarCode=@barcode";

        public MySqlDataReader readerProduct(int barcode)
        {
            try
            {
                command = new MySqlCommand(checkProduct, connection);
                command.Parameters.AddWithValue("@barcode", barcode);

                connection.Open();

                reader = command.ExecuteReader();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " +ex.Message.ToString());   
            }
            return reader;
        }

        private string addEmployer = "insert into employer(PersonID, Name) values (@personid, @name)";

        public void insertEmployer(int personid, string name)
        {
            try
            {
                command = new MySqlCommand(addEmployer, connection);   
                command.Parameters.AddWithValue("@personid", personid);
                command.Parameters.AddWithValue("@name", name);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " +ex.Message.ToString());   
            }
            finally
            {
                connection.Close();
            }
        }

        private string checkEmployer = "select * from employer where PersonID = @personid";
        public MySqlDataReader readerEmployer(int personid)
        {
            try
            {
                command = new MySqlCommand(checkEmployer, connection);
                command.Parameters.AddWithValue("@personid", personid);

                connection.Open();

                reader = command.ExecuteReader();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " +ex.Message.ToString());   
            }

            return reader;

        }

    }
}