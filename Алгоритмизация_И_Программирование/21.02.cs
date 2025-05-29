using System;
class Programa
{
    static void Main()
    {
        string input = "{[()]}";
        bool check = staples(input);
        if (check)
        {
            Console.WriteLine("Скобки раставлены правильно");
        }
        else
        {
            Console.WriteLine("Скобки раставлены не правильно");
        }
    }
    static bool staples(string input)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char s in input)
        {
            if (s == '{' || s == '[' || s == '(')
            {
                stack.Push(s);
            }
            else if (s == '}' || s == ']' || s == ')')
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                char elem = stack.Pop();
                if ((elem == '(' && s != ')') || (elem == '{' && s != '}') || (elem == '[' && s != ']'))
                {
                    return false;
                }
            }
        }
        return true;
    }
}