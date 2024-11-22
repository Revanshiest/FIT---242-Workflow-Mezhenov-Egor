using System;

namespace education
{
    public class NewClass
    {
        static void Main()
        {
            int a=Convert.ToInt32(Console.ReadLine());
            int seckolvo = int.MinValue;
            int maximum = 0;
            for (int b, i = 0; i < a; i++)
            {
                b = Convert.ToInt32(Console.ReadLine());
                if (i == 0) maximum = b; 
                if (b > maximum)
                {
                    seckolvo = maximum;
                    maximum = b;
                }
                else if (seckolvo < b && maximum > b)
                {
                    seckolvo = b;
                }

            }
        Console.WriteLine(seckolvo);
        }
    }
}