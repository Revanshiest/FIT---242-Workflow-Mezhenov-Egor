using System;
class Program
{
    static int Count(int startday, int endday, int startmonth, int endmonth, int startyear, int endyear)
    {
        int[] daymonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        int daycount = 0;
        bool visokos(int year) => (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        if (visokos(startyear))
        {
            daymonth[1] = 29;
        }
        if (startyear != endyear)
        {
            for (int month = startmonth - 1; month < 12; month++)
            {
                if (month == startmonth - 1)
                {
                    daycount += daymonth[month] - startday + 1; 
                }
                else
                {
                    daycount += daymonth[month]; 
                }
            }
            for (int year = startyear + 1; year < endyear; year++)
            {
                if (visokos(year)) daycount += 366;
                else daycount += 365;
            }
            if (visokos(endyear)) daymonth[1] = 29; 
            for (int month = 0; month < endmonth; month++)
            {
                if (month == endmonth - 1)
                {
                    daycount += endday; 
                }
                else
                {
                    daycount += daymonth[month]; 
                }
            }
        }
        else 
        {
            for (int month = startmonth - 1; month < endmonth; month++)
            {
                if (month == startmonth - 1)
                {
                    daycount += daymonth[month] - startday + 1; 
                }
                else if (month == endmonth - 1)
                {
                    daycount += endday; 
                }
                else
                {
                    daycount += daymonth[month]; 
                }
            }
        }
        return daycount;
    }
    static void Main()
    {
        Console.WriteLine("Введите дату начала периода");
        string start = Console.ReadLine();
        Console.WriteLine("Введите дату конца периода");
        string end = Console.ReadLine();
        Console.WriteLine("Введите начальный выпуск продукции:");
        int p = int.Parse(Console.ReadLine());

        int startday = int.Parse(start.Substring(0, 2));
        int startmonth = int.Parse(start.Substring(3, 2));
        int startyear = int.Parse(start.Substring(6, 4));

        int endday = int.Parse(end.Substring(0, 2));
        int endmonth = int.Parse(end.Substring(3, 2));
        int endyear = int.Parse(end.Substring(6, 4));

        int daycount = Count(startday, endday, startmonth, endmonth, startyear, endyear);
        int rez = daycount * (p + (p + (daycount - 1))) / 2;
        Console.WriteLine("Результат");
        Console.WriteLine(rez);
    }
}