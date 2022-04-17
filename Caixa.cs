using System;
using MySql.Data.MySqlClient;

namespace CaixaDeMercado
{
    class Caixa
    {
        private MySqlDataReader? reader;
       public static void Main(String[] args)
       {    
           Caixa caixa = new Caixa();
           Db db = new Db();
//           db.insertProduct(123,"mac",20.50,10);
           caixa.reader = db.readerProduct(123);
           while(caixa.reader.Read())
           {
           Console.WriteLine(Convert.ToString(caixa.reader["Name"])); 
           Console.WriteLine(Convert.ToString(caixa.reader["Price"]));
           Console.WriteLine(Convert.ToString(caixa.reader["Stock"]));
           }
           db.closesql();
       }
    }
}