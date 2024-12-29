using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество людей: ");
        int kolvo_chelovek=Convert.ToInt32(Console.ReadLine());        
        if (kolvo_chelovek>2)
        {
        int point = (int)Math.Log(kolvo_chelovek/3, 2);

        point = (int)Math.Pow(2, point);
        
        int checkpoint = 3 * point;
        
        int otvet = Math.Abs(kolvo_chelovek - checkpoint - point);
        Console.WriteLine($"otvet {otvet}");
        }
        else
        {
            Console.WriteLine("-1");
        }
    }
}