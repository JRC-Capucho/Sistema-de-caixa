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

        private string addProduct = "insert into product (Name, Price) values (@name,@price)";

        public void insertProduct(string name, double price)
        {
            try
            {
                command = new MySqlCommand(addProduct, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);

                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " + ex.Message.ToString());
            }
            finally
            {
                System.Console.WriteLine("Produto cadastrado com sucesso!");
                connection.Close();
            }
        }

        private string checkListProduct = "select * from product";

        public int listProduct()
        {
            int limit = 0;
            try
            {
                command = new MySqlCommand(checkListProduct, connection);

                connection.Open();

                System.Console.WriteLine("\n============================================\n");
                string data = "[Opções]=-=[Nome]=-----=[Preço]\n";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data += "    " + Convert.ToString(reader["id"]) + "\t  " + Convert.ToString(reader["Name"]) + "\t" + Convert.ToString(reader["Price"]) + "\n";
                    limit++;
                }
                System.Console.WriteLine(data);
                System.Console.WriteLine("============================================\n");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return limit;

        }

        private string namePriceProduct = "select name, price from product where id=@id;";

        public string getNamePrice(int id)
        {
            string data = "invalid";

            try
            {
                command = new MySqlCommand(namePriceProduct, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data = Convert.ToString(reader["Name"]) + "\t" + Convert.ToString(reader["Price"]) + "\n";
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return data;

        }

        private string priceProduct = "select Price from product where id=@id;";

        public double getPrice(int id)
        {
            string aux = "0";
            double price = 0;
            try
            {
                command = new MySqlCommand(priceProduct, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    aux = Convert.ToString(reader["Price"]);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            price = Convert.ToDouble(aux);
            return price;
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
                System.Console.WriteLine("Erro " + ex.Message.ToString());
            }
            finally
            {
                System.Console.WriteLine("Funcionario cadastrado com sucesso!");
                connection.Close();
            }
        }

        private string checkEmployer = "select Name from employer where PersonID = @personid";

        public string readerEmployer(int personid)
        {
            string name = "invalid";
            try
            {
                command = new MySqlCommand(checkEmployer, connection);
                command.Parameters.AddWithValue("@personid", personid);

                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    name = Convert.ToString(reader["Name"]);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }

            return name;

        }

        private string checkManager = "select Name from manager where PersonID = @personid";

        public string readerManager(int personid)
        {
            string name = "invalid";
            try
            {
                command = new MySqlCommand(checkManager, connection);
                command.Parameters.AddWithValue("@personid", personid);

                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    name = Convert.ToString(reader["Name"]);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine("Erro " + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }

            return name;
        }

    }
}
