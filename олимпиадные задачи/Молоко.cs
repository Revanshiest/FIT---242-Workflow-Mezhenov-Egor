using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("входные данные:");
        int number = Convert.ToInt32(Console.ReadLine());
        int minindex = -1;
        double minprice = double.MaxValue;
        double result = 0.0;
        for (int i = 0; i < number; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            int x1 = Convert.ToInt32(inputs[0]);
            int y1 = Convert.ToInt32(inputs[1]);
            int z1 = Convert.ToInt32(inputs[2]);
            int x2 = Convert.ToInt32(inputs[3]);
            int y2 = Convert.ToInt32(inputs[4]);
            int z2 = Convert.ToInt32(inputs[5]);
            double c1 = Convert.ToDouble(inputs[6]);
            double c2 = Convert.ToDouble(inputs[7]);
            double volue1 = x1 * y1 * z1;
            double volue2 = x2 * y2 * z2;
            double s1 = 2 * (x1*y1 + y1 * z1 + x1 * z1);
            double s2 = 2 * (x2*y2 + y2 * z2 + x2 * z2);
            if (c1 > c2)
            {
                double ch1 = c1 * s2 - s1 * c2;
                double ch2 = s2 * volue1 - s1 * volue2;
                result = (ch1 / ch2) * 1000;
            }
            else
            {
                double ch1 = c2 * s1 - s2 * c1;
                double ch2 = s1 * volue2 - s2 * volue1;
                result = (ch1 / ch2) * 1000;
            }
            if (minprice>result)
            {
                minprice = result;
                minindex = i + 1;
            }
            result = 0.0;
        }
        Console.WriteLine("выходные данные:");
        Console.WriteLine($"{minindex} {minprice:F2}");
    }
}