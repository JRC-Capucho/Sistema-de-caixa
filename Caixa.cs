using System;
using MySql.Data.MySqlClient;

namespace CaixaDeMercado
{
    class Caixa
    {
        private string nameProduct = "[Nome]=--------=[Preço]\n";
        private double payFinal = 0;
        private int limit;
        private string personName;
        private Db db = new Db();
        private MySqlDataReader? reader;

        public void loginSession()
        {
            System.Console.WriteLine("============================================\n");
            System.Console.WriteLine("F f = Funcionario");
            System.Console.WriteLine("G g = Gerente");
            System.Console.WriteLine("\n============================================\n");
            System.Console.WriteLine("Você e");
            string aux = Console.ReadLine();

            System.Console.WriteLine("\nDigite seu numero do crachá:");
            int personId = Convert.ToInt32(Console.ReadLine());

            switch (aux)
            {
                case "f":
                case "F":
                    personName = "[f] " + db.readerEmployer(personId);
                    break;
                case "g":
                case "G":
                    personName = "[g] " + db.readerManager(personId);
                    break;
            }
        }

        public void menuManager()
        {
            string aux;
            int option;

            do
            {
                System.Console.WriteLine("\n============================================\n");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        addProduct();
                        break;

                    case 2:
                        addEmployer();
                        break;
                }

                System.Console.WriteLine("\nS s = Sim\nN n = Não");
                System.Console.WriteLine("+------------+");

                System.Console.WriteLine("Deseja encerrar a sessão");
                aux = Console.ReadLine();

            } while (aux.Equals("n") || aux.Equals("N"));

            System.Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadLine();
        }

        public void addEmployer()
        {
            System.Console.WriteLine("============================================\n");

            System.Console.WriteLine("Digite o nome do novo Funcionario:");
            string name = Console.ReadLine();

            System.Console.WriteLine("\nDigite o numero do crachá:");
            int id = Convert.ToInt32(Console.ReadLine());

            db.insertEmployer(id, name);
            System.Console.WriteLine("\n============================================\n");

        }

        public void addProduct()
        {
            System.Console.WriteLine("============================================\n");
            System.Console.WriteLine("Digite o nome do novo produto:");
            string name = Console.ReadLine();

            System.Console.WriteLine("\nDigite o preço do novo produto:");
            double price = Convert.ToDouble(Console.ReadLine());

            db.insertProduct(name, price);
            System.Console.WriteLine("\n============================================\n");
        }



        public void menuEmployer()
        {
            string aux;
            do
            {
                menu();
                chooseProduct();

                System.Console.WriteLine("\nS s = Sim\nN n = Não");
                System.Console.WriteLine("+------------+");
                System.Console.WriteLine("Deseja finalizar a compra:");
                aux = Console.ReadLine();

            } while (aux.Equals("n") || aux.Equals("N"));
            payment();
        }

        public void menu()
        {

            System.Console.WriteLine("\nBem vindo {0}", personName.Substring(4));
            limit = db.listProduct();
        }

        public void chooseProduct()
        {
            System.Console.WriteLine("Escolha uma das opções de cima:");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option > limit)
            {
                System.Console.WriteLine("Opção invalida");
            }
            else
            {
                nameProduct += db.getNamePrice(option);
                payFinal += db.getPrice(option);
            }
        }

        public void payment()
        {
            System.Console.WriteLine("\n============================================\n");
            System.Console.WriteLine("Atendido pelo Funcionario: {0}\n", personName.Substring(4));
            System.Console.WriteLine(nameProduct);
            System.Console.WriteLine("--------------------------------------------\n");
            System.Console.WriteLine("Total a pagar: {0:F2}", payFinal);
            System.Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadLine();
        }


        public static void Main(String[] args)
        {
            Caixa caixa = new Caixa();

            caixa.loginSession();


            if (caixa.personName.Contains("invalid"))
            {
                System.Console.WriteLine("Cracha invalido");
            }
            else
            {
                if (caixa.personName[1].Equals('f'))
                {
                    caixa.menuEmployer();
                }
                if (caixa.personName[1].Equals('g'))
                {
                    caixa.menuManager();
                }
            }
        }

    }
}
