using System;
class Program
{
    static void Main()
    {
        string n = Console.ReadLine();
        int a = 0, b = 0, c = 0, max = 0, x = 0;
        for (int i = 0; i < n.Length; i++)
        {
            if (i != 0 && n[i - 1] == 'a' && n[i] == 'a')
            {
                a = 1;
            }
            else if (n[i] == 'a')
            {
                a++;
            }
            else if (n[i] == 'b')
            {
                if (a > b)
                {
                    b++;
                }
            }
            else if (n[i] == 'c')
            {
                if (b > c)
                {
                    c++;
                }
            }
            else
            {
                a = 0;
                b = 0;
                c = 0;
            }
            x = a + b + c;
            if (x > max)
            {
                max = x;
            }
        }
        Console.WriteLine(max);
    }
}