using System;
class Fig
{
    public string Name { get; set; }
}
interface Form
{
    double Perimeter();
    double Square();
}
class Circle : Fig, Form
{
    public double Radius { get; set; }
    public double Perimeter()
    {
        return 2 * 3.14 * Radius;
    }
    public double Square()
    {
        return 3.14 * (Radius * Radius);
    }
}
class Box : Fig, Form
{
    public double Side { get; set; }
    public double Perimeter()
    {
        return 4 * Side;
    }
    public double Square()
    {
        return Side * Side;
    }
}
class Triangle : Fig, Form
{
    public double Edge { get; set; }
    public double Perimeter()
    {
        return 3 * Edge;
    }
    public double Square()
    {
        return (Math.Sqrt(3) * Edge * Edge) / 4;
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите радиус окружности");
        double radius = double.Parse(Console.ReadLine());
        var circle = new Circle { Name = "Окружность", Radius = radius };

        Console.WriteLine("Введите сторону квадрата");
        double storona = double.Parse(Console.ReadLine());
        var square = new Box { Name = "Квадрат", Side = storona };

        Console.WriteLine("Введите сторону равностороннего треугольника");
        double rebro = double.Parse(Console.ReadLine());
        var triangle = new Triangle { Name = "Треугольник", Edge = rebro };

        Console.WriteLine($"\nФигура: {circle.Name}");
        Console.WriteLine($"Периметр: {circle.Perimeter()}");
        Console.WriteLine($"Площадь: {circle.Square()}");

        Console.WriteLine($"\nФигура: {square.Name}");
        Console.WriteLine($"Периметр: {square.Perimeter()}");
        Console.WriteLine($"Площадь: {square.Square()}");

        Console.WriteLine($"\nФигура: {triangle.Name}");
        Console.WriteLine($"Периметр: {triangle.Perimeter()}");
        Console.WriteLine($"Площадь: {triangle.Square()}");
    }
}