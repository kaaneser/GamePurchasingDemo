using GamePurchasingDemo.Abstract;
using GamePurchasingDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePurchasingDemo.Concrete
{
    class GameManager:ISalesService
    {
        List<Game> games = new List<Game>();
        List<Sale> sales = new List<Sale>();

        public void Add(Game game)
        {
            games.Add(game);
            Console.WriteLine(game.gameName + " has been added successfully.");
        }

        public void ShowList()
        {
            if (games.Count == 0)
            {
                Console.WriteLine("Can't find any game.");
            }
            else
            {
                for (int i = 0; i < games.Count; i++)
                {
                    Console.WriteLine("--- Game " + (i + 1) + " ---");
                    Console.WriteLine("Game ID: " + games[i].Id);
                    Console.WriteLine("Game Name: " + games[i].gameName);
                    Console.WriteLine("Release Year: " + games[i].releaseYear);
                    Console.WriteLine("Price: " + games[i].price + " TL\n");
                }
            }
        }

        public void Purchase()
        {
            Console.WriteLine("Insert a Game ID to purchase: ");
            int gameId = Convert.ToInt32(Console.ReadLine());
            foreach (var game in games)
            {
                if(game.Id == gameId)
                {
                    Console.WriteLine("You'll purchase " + game.gameName);
                    Console.WriteLine("1. Go to checkout \t 2.Sales Operations \n Select a choice:");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.WriteLine("You purchased the item " + game.gameName + ", Price: " + game.price);
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("1. Apply a sale to: " + game.gameName + " \t 2. Add a new sale to db \t 3. Delete a sale from db \n Select a choice:");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Insert to Sale ID:");
                                int saleId = Convert.ToInt32(Console.ReadLine());
                                foreach (var item in sales)
                                {
                                    if (item.saleId == saleId)
                                    {
                                        ApplySale(item, game);
                                    }
                                }
                                break;
                            case 2:
                                Console.WriteLine("Sale ID: ");
                                int Id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Sale Name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Discount Percantage: ");
                                int discount = Convert.ToInt32(Console.ReadLine());
                                Sale sale = new Sale() { saleId = Id, saleName = name, discountPercentage = discount};
                                AddSale(sale);
                                break;
                            default:
                                Console.WriteLine("You inserted wrong number.");
                                break;
                        }
                    }
                }
            }
        }

        public void AddSale(Sale sale)
        {
            sales.Add(sale);
            Console.WriteLine("Sale added to db successfully.");
        }

        public void ApplySale(Sale sale, Game game)
        {
            double discountedPrice = 0.0;
            discountedPrice += game.price * (sale.discountPercentage / 100);
            Console.WriteLine(sale.saleName + " sale applied.");
            Console.WriteLine(game.gameName + " discounted, the new price is: " + discountedPrice + " TL");
        }
    }
}
