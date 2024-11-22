using System;

namespace education
{
    public class NewClass
    {
        static void Main()
        {
        int a = Convert.ToInt32(Console.ReadLine());

        int b = Convert.ToInt32(Console.ReadLine());

        int max = (a + b + Math.Abs(a - b)) / 2;
        Console.WriteLine(max);

        int min = (a + b - Math.Abs(a - b)) / 2;
        Console.WriteLine(min);
        }
    }
}