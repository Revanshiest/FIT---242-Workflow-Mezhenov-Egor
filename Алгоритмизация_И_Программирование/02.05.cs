using System;
using System.Linq;
using System.Collections.Generic;

class Provider
{
    public int Id { get; set; }
    public string ProviderName { get; set; }
    public string ContactNumber { get; set; }
    public string ProviderCity { get; set; }

    public Provider(int id, string name, string number, string city)
    {
        Id = id;
        ProviderName = name;
        ContactNumber = number;
        ProviderCity = city;
    }
}

class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }

    public Product(int id, string name)
    {
        Id = id;
        ProductName = name;
    }
}

class Movement
{
    public int ProductId { get; set; }
    public int ProviderId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string MovementDate { get; set; }
    public bool IsComing { get; set; }

    public Movement(int productId, int providerId, int quantity, int price, string date, bool isComing)
    {
        ProductId = productId;
        ProviderId = providerId;
        Quantity = quantity;
        Price = price;
        MovementDate = date;
        IsComing = isComing;
    }
}

class Program
{
    static void Main()
    {
        List<Provider> providerList = new List<Provider>();
        Provider provider1 = new Provider(1, "provider1", "+7904", "Omsk");
        Provider provider2 = new Provider(2, "provider2", "+7950", "Moscow");
        providerList.Add(provider1);
        providerList.Add(provider2);

        List<Product> productList = new List<Product>();
        Product product1 = new Product(1, "product1");
        Product product2 = new Product(2, "product2");
        productList.Add(product1);
        productList.Add(product2);

        List<Movement> movementList = new List<Movement>();
        Movement movement1 = new Movement(product1.Id, provider1.Id, 5, 200, "20.05.2025", true);
        Movement movement2 = new Movement(product2.Id, provider2.Id, 12, 2000, "20.06.2025", true);
        Movement movement3 = new Movement(product1.Id, provider2.Id, 3, 12, "29.05.2025", false);
        Movement movement4 = new Movement(product2.Id, provider1.Id, 27, 512, "20.04.2025", true);
        movementList.Add(movement1);
        movementList.Add(movement2);
        movementList.Add(movement3);
        movementList.Add(movement4);

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\tМеню");
            Console.WriteLine("1. Количество остатков товара в магазине");
            Console.WriteLine("2. Сгруппировать поставки товара по дате");
            Console.WriteLine("3. Сгруппировать поставки товара по поставщику");
            Console.WriteLine("4. Выдать движение товара сгруппированного по артикулу");
            Console.WriteLine("5. Выход");

            int menuChoice;
            if (!int.TryParse(Console.ReadLine(), out menuChoice))
            {
                Console.WriteLine("Неверный ввод. Введите число от 1 до 5.");
                continue;
            }

            switch (menuChoice)
            {
                case 1:
                    var productBalanceList = from m in movementList
                                             group m by m.ProductId into g
                                             join p in productList on g.Key equals p.Id
                                             select new
                                             {
                                                 ProductId = g.Key,
                                                 ProductName = p.ProductName,
                                                 Balance = g.Sum(x => x.IsComing ? x.Quantity : -x.Quantity)
                                             };
                    Console.WriteLine("\nОстатки товаров:");
                    foreach (var item in productBalanceList)
                    {
                        Console.WriteLine($"{item.ProductName}: {item.Balance} штук");
                    }
                    break;
                case 2:
                    var incomingMovementsByDate = from m in movementList
                                                  where m.IsComing
                                                  group m by m.MovementDate into g
                                                  orderby g.Key
                                                  select g;

                    Console.WriteLine("\nПоставки товаров по датам:");
                    foreach (var group in incomingMovementsByDate)
                    {
                        Console.WriteLine($"Дата: {group.Key}");
                        foreach (var movement in group)
                        {
                            var product = productList.First(p => p.Id == movement.ProductId);
                            Console.WriteLine($"Товар: {product.ProductName}, Количество: {movement.Quantity}, Цена: {movement.Price}");
                        }
                    }
                    break;
                case 3:
                    var incomingMovementsByProvider = from m in movementList
                                                  where m.IsComing
                                                  group m by m.ProviderId into g
                                                  join p in providerList on g.Key equals p.Id
                                                  select new
                                                  {
                                                      ProviderName = p.ProviderName,
                                                      Movements = g
                                                  };
                    Console.WriteLine("\nПоставки товаров по поставщикам:");
                    foreach (var group in incomingMovementsByProvider)
                    {
                        Console.WriteLine($"Поставщик: {group.ProviderName}");
                        foreach (var movement in group.Movements)
                        {
                            var product = productList.First(p => p.Id == movement.ProductId);
                            Console.WriteLine($"Товар: {product.ProductName}, Дата: {movement.MovementDate}, Количество: {movement.Quantity}, Цена: {movement.Price}");
                        }
                    }
                    break;
                case 4:
                    var allMovementsByProduct = from m in movementList
                                            group m by m.ProductId into g
                                            join p in productList on g.Key equals p.Id
                                            orderby p.Id
                                            select new
                                            {
                                                ProductName = p.ProductName,
                                                Movements = g
                                            };
                    Console.WriteLine("\nДвижение товаров:");
                    foreach (var group in allMovementsByProduct)
                    {
                        Console.WriteLine($"Товар: {group.ProductName}");
                        foreach (var movement in group.Movements)
                        {
                            var provider = providerList.First(p => p.Id == movement.ProviderId);
                            string operation = movement.IsComing ? "Поступление" : "Продажа";
                            Console.WriteLine($"{operation}, Поставщик: {provider.ProviderName}, Дата: {movement.MovementDate}, Количество: {movement.Quantity}, Цена: {movement.Price}");
                        }
                    }
                    break;
                case 5:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Введите число от 1 до 5.");
                    break;
            }
        }
    }
}