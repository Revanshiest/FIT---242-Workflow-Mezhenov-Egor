using System;

namespace education
{
    public class NewClass
    {
        static void Main()
        {
            int a=Convert.ToInt32(Console.ReadLine());
            int ch1 = 0;
            int ch2 = 0;
            int kolvo = 0;
            for (int b, i = 0; i < a; i++)
            {
                b = Convert.ToInt32(Console.ReadLine());
                if (i == 0)
                {
                    ch1 = b;
                }
                else if (i == 1)
                {
                    ch2 = b;
                }
                else
                {
                    if (ch1 > ch2 && ch2 < b)
                    {
                        kolvo++;
                    }
                    ch1 = ch2;
                    ch2 = b;
                }
            }
        Console.WriteLine(kolvo);
        }
    }
}