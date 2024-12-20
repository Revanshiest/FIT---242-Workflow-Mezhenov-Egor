using System;
class HelloWorld 
{
    static void Main() 
    {
        int num, max = 0, sum = 0, pos;
        num=Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < num; i++) 
        {
            pos = Convert.ToInt32(Console.ReadLine());
            if (pos % 2 == 0) 
            { 
                sum += pos;
            }
            else 
            {
                if (sum > max) 
                {
                    max = sum; 
                }
                sum = 0;
            }
        }
        if (sum > max) 
        {
            max = sum;
        }
        Console.WriteLine(max);
    }
}