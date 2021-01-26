using GamePurchasingDemo.Concrete;
using GamePurchasingDemo.Entities;
using System;
using System.IO;

namespace GamePurchasingDemo
{
    class Program
    {
        static void Signup(CustomerManager customerManager)
        {
            Console.WriteLine("Add an existing TC number:");
            string tcNo = Console.ReadLine();
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Date of year:");
            int year = Convert.ToInt32(Console.ReadLine());

            Customer customer = new Customer() {TcNo = tcNo, Name = name, Surname = surname, birthYear = year };
            customerManager.Add(customer);
        }
        static void Login(CustomerManager customerManager)
        {
            Console.WriteLine("TC Number: ");
            string tcNo = Console.ReadLine();
            Customer customer = customerManager.Login(tcNo);
            
            if (customer != null)
            {
                GameManager gameManager = new GameManager();
                bool loggedIn = true;
                while (loggedIn)
                {
                    Console.WriteLine("1. Add a Game/Games \t 2. Game List \t 3. Purchase a Game \t 4. Log out");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("How much game do you want to add?: ");
                            int numbers_to_add = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < numbers_to_add; i++)
                            {
                                Game game = new Game();
                                Console.WriteLine("ID of the game: ");
                                int Id = Convert.ToInt32(Console.ReadLine());
                                game.Id = Id;
                                Console.WriteLine("Name of the game: ");
                                string name = Console.ReadLine();
                                game.gameName = name;
                                Console.WriteLine("Release year?: ");
                                int year = Convert.ToInt32(Console.ReadLine());
                                game.releaseYear = year;
                                Console.WriteLine("Game price: ");
                                double price = Convert.ToDouble(Console.ReadLine());
                                game.price = price;
                                gameManager.Add(game);
                            }
                            break;
                        case 2:
                            gameManager.ShowList();
                            break;
                        case 3:
                            gameManager.Purchase();
                            break;
                        case 4:
                            Console.WriteLine("Cya, " + customer.Name + "!\n");
                            loggedIn = false;
                            break;
                        default:
                            Console.WriteLine("You have inserted wrong number! Please try again.");
                            break;
                    }
                }
            }
        }

        static void Update(CustomerManager customerManager)
        {
            Console.WriteLine("Customer is updating...");
            customerManager.Update();
        }

        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            bool exitCode = true;
            while (exitCode)
            {
                Console.WriteLine("1. Signup \t 2. Login \t 3. Update Profile \t 4. Quit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Signup(customerManager);
                        break;
                    case 2:
                        Login(customerManager);
                        break;
                    case 3:
                        Update(customerManager);
                        break;
                    case 4:
                        exitCode = false;
                        break;
                    default:
                        Console.WriteLine("You pressed the wrong number.");
                        break;
                }
            }
            
        }
    }
}
