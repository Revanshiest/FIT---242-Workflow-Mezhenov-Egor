using System;
class Programa
{
    static void Main()
    {
        int result = 0;
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');
        
        if (parts.Length != 3 )
        {
            Console.WriteLine("Неверное количество элементов");
            return;
        }
        
        Stack<int> stack = new Stack<int>();

        foreach(var part in parts.Take(2))
        {
            if(!int.TryParse(part, out result))
            {
                Console.WriteLine("Неверный формат ввода");
                return;
            }
        }
        
        int num1 = int.Parse(parts[0]);
        int num2 = int.Parse(parts[1]);
        
        stack.Push(num1);
        stack.Push(num2);
        string operation = parts[2];
        
        if (operation == "+")
        {
            result = stack.Pop() + stack.Pop();
            Console.WriteLine(result);
        }
        else if (operation == "-")
        {
            int secondNum = stack.Pop();
            int firstNum = stack.Pop();
            result = firstNum - secondNum;
            Console.WriteLine(result);
        }
        else if (operation == "*")
        {
            result = stack.Pop() * stack.Pop();
            Console.WriteLine(result);
        }
        else if (operation == "/")
        {
            int secondNum = stack.Pop();
            int firstNum = stack.Pop();
            if (secondNum == 0)
            {
                Console.WriteLine("Делить на ноль нельзя");
            }
            else
            {
                result = firstNum / secondNum;
                Console.WriteLine(result);
            }
        }
        else
        {
            Console.WriteLine("Неверно введена операция");
        }
    }
}