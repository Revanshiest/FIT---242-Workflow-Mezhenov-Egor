using System;
class Programa
{
    static void Main()
    {
        List<char> list = new List<char> { 'a', 'b', 'c', 'a', 'c' };
        HashSet<char> set = new HashSet<char>(list);
        Console.WriteLine("Сет списка");
        foreach (char current in set)
        {
            Console.WriteLine(current);
        }

        Dictionary<char, int> symbols = new Dictionary<char, int>();
        foreach (char current in list)
        {
            if (symbols.ContainsKey(current))
            {
                symbols[current]++;
            }
            else
            {
                symbols.Add(current, 1);
            }
        }
        Console.WriteLine("\nЧастота вхождения каждого символа");
        foreach (var symbol in symbols)
        {
            Console.WriteLine($"{symbol.Key}: {symbol.Value}");
        }
    }
}