using System;

class Sub
{
    public string Name {get; set;}
    public List<Phone> Phones {get; set; }
    public Sub (string name)
    {
        Name = name;
        Phones = new List<Phone>();
    }
    public void AddPhone(Phone phone)
    {
        Phones.Add(phone);
    }
    public override string ToString()
    {
        string phonesInfo = string.Join("\n ", Phones.Select(p => p.ToString()));
        return $"Абонент: {Name} - {phonesInfo}";
    }
}

class Phone
{
    public string Number {get; set;}
    public string Operator {get; set;}
    public int YearAdd {get; set;}
    public string City {get; set;}

    public Phone (string number, string oper, int year, string city)
    {
        Number = number;
        Operator = oper;
        YearAdd = year;
        City = city;
    }
    public override string ToString()
    {
        return $"номер: {Number} оператор: {Operator} год подключения: {YearAdd} город: {City}";
    }

}
class Programa()
{
    static Sub AddSub()
    {
        Console.WriteLine("Введите имя пользователя:");
        Sub user = new Sub(Console.ReadLine());
        int k = 1;
        while(k == 1)
        {    
        k = 0;
        Console.WriteLine("Введите номер:");
        string Numb = Console.ReadLine();
        Console.WriteLine("Введите оператора связи:");
        string Operat = Console.ReadLine();
        Console.WriteLine("Введите год подключения:");
        int yearg = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите город:");
        string cit = Console.ReadLine();
        user.AddPhone(new Phone(Numb, Operat, yearg, cit));
        Console.WriteLine("Если хотите добавить ещё один номер нажмите 1");
        k = Convert.ToInt32(Console.Read());
        }
        return user;
    }

    static void SearchCity(List<Sub> subs, string city)
{
    var found = subs.Where(s=> s.Phones.Any(p => p.City.Equals(city, StringComparison.OrdinalIgnoreCase)));
    foreach (var s in found)
    {
        Console.WriteLine(s);
    }
}
    static void SearchNumber(List<Sub> subs, string number)
{
    var found = subs.Where(s=> s.Phones.Any(p => p.Number.Equals(number, StringComparison.OrdinalIgnoreCase)));
    foreach (var s in found)
    {
        Console.WriteLine(s);
    }
}
    static void SearchOperator(List<Sub> subs, string oper)
{
    var found = subs.Where(s=> s.Phones.Any(p => p.City.Equals(oper, StringComparison.OrdinalIgnoreCase)));
    foreach (var s in found)
    {
        Console.WriteLine(s);
    }
}
    static void SearchYear(List<Sub> subs, int year)
{
    var found = subs.Where(s=> s.Phones.Any(p => p.YearAdd == year));
    foreach (var s in found)
    {
        Console.WriteLine(s);
    }
}

    static void Main()
    {
        List<Sub> subs = new List<Sub>();
        while (true)
        {
            Console.WriteLine("\nМеню");
            Console.WriteLine("1. Добавить Абонента");
            Console.WriteLine("2. Показать всех абонентов");
            Console.WriteLine("3. Поиск по городу");
            Console.WriteLine("4. Поиск по номеру телефона");
            Console.WriteLine("5. Поиск по оператору связи");
            Console.WriteLine("6. Поиск по году подключения");
            Console.WriteLine("7. Выход из программы");
            string choice = Console.ReadLine();

            switch (choice)
            {
            case "1":
                Sub u = AddSub();
                subs.Add(u);
                break;

            case "2":
                foreach (var sub in subs)
                    Console.WriteLine(sub);
                break;
            case "3":
                Console.Write("Введите город: ");
                SearchCity(subs, Console.ReadLine());
                break;
            case "4":
                Console.Write("Введите номер: ");
                SearchNumber(subs, Console.ReadLine());
                break;
            case "5":
                Console.Write("Введите оператора: ");
                SearchOperator(subs, Console.ReadLine());
                break;
            case "6":
                Console.Write("Введите год подключения: ");
                if (int.TryParse(Console.ReadLine(), out int year))
                    SearchYear(subs, year);
                else
                    Console.WriteLine("Неверный формат года.");
                break;
            case "7":
                return;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
            }
        }
    }
}