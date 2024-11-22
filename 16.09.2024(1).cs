using System;

namespace education
{
    public class NewClass
    {
        static void Main()
        {
            int a=Convert.ToInt32(Console.ReadLine());
            int kolvo = 0;
            for (int b, i = 0; i < a; i++)
            {
                b = Convert.ToInt32(Console.ReadLine());
                if (b < 0) kolvo++;
            }
        Console.WriteLine(kolvo);
        }
    }
}