using System;
delegate int Lyam(int x, int y);
class Program
{
    static void Main()
    {
        Console.WriteLine("значение первой переменной: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("значение второй переменной: ");
        int b = int.Parse(Console.ReadLine());
        int result = 0;
        if (b == 0)
        {
            Console.WriteLine("На 0 делить нельзя");
            return;
        }
        Lyam lyam = (x, y) => (x + y) * (x / y) - (x * y);
        result = lyam(a, b);
        Console.WriteLine($"Результат: {result}");
    }
}