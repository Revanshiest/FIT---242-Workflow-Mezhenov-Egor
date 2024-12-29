using System;
class operation
{
    public operation(double a, double b)
    {
        x = a;
        y = b;
        if (x == 0 && y == 0)
        {
            Console.WriteLine("переменные равны 0");
        }
    }
    double x, y;
    public double Slozh(double a, double b)
    {
        return x+y;
    }
    public double Vichit(double a, double b)
    {
        return x - y;
    }
    public double Umnozh(double a, double b)
    {
        return x * y;
    }
    public double Delit(double a, double b)
    {
        if (y!=0)
        {
            return x / y;
        }
        else 
        {
            Console.WriteLine("делить на 0 нельзя");
            return 0;
        }
    }   
}

class Programm
{
    static void Main()
    {
        Console.WriteLine("введите первое число:");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("введите второе число:");
        double b = Convert.ToDouble(Console.ReadLine());
        operation obj = new operation(a, b);
        Console.WriteLine("сложение: " + obj.Slozh(a, b));
        Console.WriteLine("вычитание: " + obj.Vichit(a, b));
        Console.WriteLine("умножение: " + obj.Umnozh(a, b));
        Console.WriteLine("деление: " + obj.Delit(a, b));
    }
}