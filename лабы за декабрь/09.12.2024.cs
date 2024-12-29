using System;

class Poezd
{
    public string Punkt { get; set; }
    public int NumPoezd { get; set; }
    public string Otpravka { get; set; }

    public Poezd(string punkt, int numPoezd, string otpravka)
    {
        Punkt = punkt;
        NumPoezd = numPoezd;
        Otpravka = otpravka;
    }

    public override string ToString()
    {
        return $"\nНомер поезда: {NumPoezd}, Пункт назначения: {Punkt}, Время отправки: {Otpravka}";
    }
}

class Stantion
{
    public string NameStan { get; private set; }
    private Poezd[] poezds;
    private int count;

    public Stantion(string nameStan, int maxPoezdCount)
    {
        NameStan = nameStan;
        poezds = new Poezd[maxPoezdCount];
        count = 0;
    }

    public void AddPoezd(Poezd poezd)
    {
        if (count < poezds.Length)
        {
            poezds[count] = poezd;
            count++;
        }
        else
        {
            Console.WriteLine("Достигнуто максимальное количество поездов.");
        }
    }

    public void Search(string time)
    {
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (poezds[i].Otpravka == time)
            {
                Console.WriteLine(poezds[i]);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Таких поездов нет.");
        }
    }

    public void Input()
    {
        Console.WriteLine("\nВведите количество поездов для добавления: ");
        int toAddCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < toAddCount; i++)
        {
            if (count >= poezds.Length)
            {
                Console.WriteLine("Достигнуто максимальное количество поездов. Прекращаем ввод.");
                break;
            }

            Console.WriteLine("\nВведите название пункта назначения: ");
            string punkt = Console.ReadLine();

            Console.WriteLine("Введите номер поезда: ");
            int numPoezd = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите время отправки: ");
            string otpravka = Console.ReadLine();

            Poezd poezd = new Poezd(punkt, numPoezd, otpravka);
            AddPoezd(poezd);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите название станции: ");
        string stationName = Console.ReadLine();

        Console.WriteLine("Введите максимальное количество поездов: ");
        int maxPoezdCount = int.Parse(Console.ReadLine());

        Stantion station = new Stantion(stationName, maxPoezdCount);

        bool a = true;
        while (a)
        {
            Console.WriteLine("\n" + "\tМеню");
            Console.WriteLine("1. Заполнение");
            Console.WriteLine("2. Поиск по времени");
            Console.WriteLine("3. Выход");

            int vipor = int.Parse(Console.ReadLine());
            if (vipor == 1)
            {
                station.Input();
            }
            else if (vipor == 2)
            {
                Console.WriteLine("\nВведите интересующее вас время: ");
                string time = Console.ReadLine();
                station.Search(time);
            }
            else if (vipor == 3)
            {
                a = false;
                break;
            }
            else
            {
                Console.WriteLine("Такой операции не существует");
            }
        }
    }
}