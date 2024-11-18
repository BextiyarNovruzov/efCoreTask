using EFCore.Helpers;
using EFCore.Models;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Register  2. Login  3. Exit");
                Console.WriteLine("Which option do you choose?");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("------------------------- Register -----------------------------");

                        Console.Write("Enter your name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter your username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string password = Console.ReadLine();

                        SqlHelper.RegisterUser(name, username, password);
                        Console.WriteLine("Successfully registered.");
                        break;

                    case "2":
                        Console.WriteLine("-------------------------- Login ------------------------------");

                        Console.WriteLine("Enter your username:");
                        string loginUsername = Console.ReadLine();
                        Console.WriteLine("Enter your password:");
                        string loginPassword = Console.ReadLine();

                        if (SqlHelper.ReadUser(loginUsername, loginPassword))
                        {
                            bool userMenu = true;
                            while (userMenu)
                            {
                                Console.WriteLine("------------------------ User Menu ----------------------------");
                                Console.WriteLine("1. See Products    2. See Basket    3. Sign Out");
                                Console.WriteLine("Which option do you choose?");

                                string userOption = Console.ReadLine();

                                switch (userOption)
                                {
                                    case "1":
                                        Console.WriteLine("------------------------- Products ------------------------------");
                                        SqlHelper.GetAllProducts();

                                        Console.WriteLine("Enter the product ID to add to Basket or 0 to return to the previous menu.");
                                        if (int.TryParse(Console.ReadLine(), out int id) && id != 0)
                                        {
                                            Console.WriteLine("Name the basket:");
                                            string basketName = Console.ReadLine();
                                            SqlHelper.AddProductToBasket(id, basketName);
                                        }
                                        break;

                                    case "2":
                                        Console.WriteLine("------------------------- Basket ------------------------------");
                                        SqlHelper.GetProductsInBasket();
                                        break;

                                    case "3":
                                        Console.WriteLine("Signed out successfully.");
                                        userMenu = false; // User menu dövründən çıxış
                                        break;

                                    default:
                                        Console.WriteLine("Invalid option. Try again.");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        running = false; // Əsas dövrü dayandırmaq
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
