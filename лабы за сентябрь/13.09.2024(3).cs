using System;

namespace education
{
    public class NewClass
    {
        static void Main()
        {
        
        Console.WriteLine("ширина");

        int m = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("высота");

        int x = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("количество грядок");

        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("расстояние от колодца до грядок");

        int k = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine((m+x)*2*n + k*2*n + n*(n-1)*x);
        }
    }
}