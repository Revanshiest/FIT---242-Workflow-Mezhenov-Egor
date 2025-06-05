using System;
using System.Linq;
using System.Collections.Generic;
using System.Random;

class Computer
{
    public int Id { get; set; }
    public string ComputerName { get; set; }
    public string Model { get; set; }
    public string OperatingSystem { get; set; }
}

class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public bool HasComputer { get; set; }
    public Computer Computer { get; set; }

    public override string ToString()
    {
        string userInfoString = "";
        if (!HasComputer)
        {
            userInfoString += $"Пользователь: {UserName}, Компьютер: Отсутствует";
        }
        else
        {
            userInfoString += $"Пользователь: {UserName}, Компьютер: {Computer.ComputerName}, Модель: {Computer.Model}, ОС: {Computer.OperatingSystem}";
        }
        return userInfoString;
    }
}

class Program
{
    static void DisplayUsersWithoutComputers(List<User> userList)
    {
        var usersWithoutComputers = userList.Where(user => !user.HasComputer).OrderBy(user => user.UserName).ToList();
        foreach (var user in usersWithoutComputers)
        {
            Console.WriteLine(user.ToString());
        }
    }

    static void DisplayUsersByOperatingSystem(List<User> userList)
    {
        Console.WriteLine("Введите ОС, по которой хотите сделать группировку: ");
        string searchOperatingSystem = Console.ReadLine();
        var usersWithOS = userList.Where(user => user.HasComputer && user.Computer.OperatingSystem == searchOperatingSystem).ToList();

        if (usersWithOS.Count == 0)
        {
            Console.WriteLine("Пользователи не найдены.");
        }
        else
        {
            Console.WriteLine($"Пользователи с ОС: {searchOperatingSystem}");
            foreach (var user in usersWithOS)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }

    static void DisplayUsersByComputerName(List<User> userList)
    {
        Console.WriteLine("Введите название ноутбука, по которому хотите сделать группировку: ");
        string searchComputerName = Console.ReadLine();
        var usersWithComputer = userList.Where(user => user.HasComputer && user.Computer.ComputerName == searchComputerName).OrderBy(user => user.UserName).ToList();

        if (usersWithComputer.Count == 0)
        {
            Console.WriteLine("Пользователи не найдены.");
        }
        else
        {
            Console.WriteLine($"Пользователи с компьютером: {searchComputerName}");
            foreach (var user in usersWithComputer)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }

    static void Main()
    {
        List<User> userList = new List<User>();

        // Новые данные пользователей
        userList.Add(new User { Id = 1, UserName = "Алексей", HasComputer = true, Computer = new Computer() { Id = 101, ComputerName = "HP", Model = "Pavilion", OperatingSystem = "Windows 10" } });
        userList.Add(new User { Id = 2, UserName = "Мария", HasComputer = false, Computer = null });
        userList.Add(new User { Id = 3, UserName = "Иван", HasComputer = true, Computer = new Computer() { Id = 102, ComputerName = "Dell", Model = "XPS", OperatingSystem = "Ubuntu" } });
        userList.Add(new User { Id = 4, UserName = "Елена", HasComputer = true, Computer = new Computer() { Id = 103, ComputerName = "Lenovo", Model = "IdeaPad", OperatingSystem = "Windows 11" } });
        userList.Add(new User { Id = 5, UserName = "Петр", HasComputer = false, Computer = null });
        userList.Add(new User { Id = 6, UserName = "Анна", HasComputer = true, Computer = new Computer() { Id = 104, ComputerName = "Apple", Model = "MacBook Air", OperatingSystem = "macOS" } });
        userList.Add(new User { Id = 7, UserName = "Дмитрий", HasComputer = true, Computer = new Computer() { Id = 105, ComputerName = "Asus", Model = "ZenBook", OperatingSystem = "Windows 10" } });

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\tМеню");
            Console.WriteLine("1. Выдать пользователей без ноутбука, отсортированных по алфавиту");
            Console.WriteLine("2. Выдать пользователей, сгруппированных по ОС");
            Console.WriteLine("3. Выдать пользователей, сгруппированных по ноутбуку, по алфавиту");
            Console.WriteLine("4. Выход");

            int menuChoice;
            if (!int.TryParse(Console.ReadLine(), out menuChoice))
            {
                Console.WriteLine("Неверный ввод. Введите число от 1 до 4.");
                continue;
            }

            switch (menuChoice)
            {
                case 1:
                    DisplayUsersWithoutComputers(userList);
                    break;
                case 2:
                    DisplayUsersByOperatingSystem(userList);
                    break;
                case 3:
                    DisplayUsersByComputerName(userList);
                    break;
                case 4:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Введите число от 1 до 4.");
                    break;
            }
        }
    }
}