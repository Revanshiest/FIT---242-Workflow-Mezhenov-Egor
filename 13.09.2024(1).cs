using System;

namespace education
{
    public class NewClass
    {
        static void Main()
        {
        int a = Convert.ToInt32(Console.ReadLine());

        int b = Convert.ToInt32(Console.ReadLine());

        int c = b;

        b = a;

        a = c;

        Console.WriteLine($"a = {a}, b = {b}");
        }
    }
}