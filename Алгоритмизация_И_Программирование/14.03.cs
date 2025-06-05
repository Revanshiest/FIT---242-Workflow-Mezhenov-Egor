using System;
class Methods
{
    public int X { get; set; }
    public int Y { get; set; }
    public Methods(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int Add()
    {
        return X + Y;
    }
    public int Subtract()
    {
        return X - Y;
    }
    public int Multiply()
    {
        return X * Y;
    }
    public int Divide()
    {
        if (Y == 0)
        {
            Console.WriteLine("Делить на ноль нельзя");
            return 0;
        }
        else
        {
            return X / Y;
        }
    }
}

delegate int Operation();

class Program
{
    static int GetValueX(Methods obj) { return obj.Add() - obj.Y; }
    static int MultiplyXByY(Methods obj) { return GetValueX(obj) * obj.Y; }
    static int AddYToDivisionResult(Methods obj) { return obj.Divide() + obj.Y; }
    static int MultiplyResultOfAddYToDivisionResultByY(Methods obj) { return AddYToDivisionResult(obj) * obj.Y; }
    static void Main()
    {
        Console.WriteLine("Введите числа");
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());

        Methods firstObject = new Methods(x, y);
        Methods secondObject = new Methods(x, y);

        Operation firstObjectOperations = firstObject.Add;
        firstObjectOperations += () => GetValueX(firstObject);
        firstObjectOperations += () => MultiplyXByY(firstObject);

        Operation secondObjectOperations = secondObject.Divide;
        secondObjectOperations += () => AddYToDivisionResult(secondObject);
        secondObjectOperations += () => MultiplyResultOfAddYToDivisionResultByY(secondObject);

        Console.WriteLine("Результаты для первого объекта");
        foreach (Operation operation in firstObjectOperations.GetInvocationList())
        {
            Console.WriteLine(operation());
        }

        Console.WriteLine("\nРезультаты для второго объекта");
        foreach (Operation operation in secondObjectOperations.GetInvocationList())
        {
            Console.WriteLine(operation());
        }
    }
}