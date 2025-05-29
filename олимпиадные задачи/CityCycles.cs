// Решение ргр задачи по алгоритмизации и программированию "игра Города (эйлеровы циклы)"

using System;
using System.Collections.Generic;
using System.IO;

class CityCyclesSolver
{
    static void Main(string[] args)
    {х
        var cities = new List<string>();
        using (var reader = new StreamReader("input.txt"))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    cities.Add(line.Trim());
            }
        }

        var graph = new Dictionary<char, Stack<(char, string)>>();
        foreach (var city in cities)
        {
            char from = city[0];
            char to = city[city.Length - 1];
            if (!graph.ContainsKey(from))
                graph[from] = new Stack<(char, string)>();
            graph[from].Push((to, city));
        }

        var used = new HashSet<string>();
        var cycleLengths = new List<int>();

        while (used.Count < cities.Count)
        {
            char? start = null;
            foreach (var kv in graph)
            {
                if (kv.Value.Count > 0)
                {
                    start = kv.Key;
                    break;
                }
            }
            if (start == null)
                break;

            var stack = new Stack<char>();
            var path = new List<char>();
            var localCities = new List<string>();
            stack.Push(start.Value);
            while (stack.Count > 0)
            {
                char v = stack.Peek();
                if (graph.ContainsKey(v) && graph[v].Count > 0)
                {
                    var (u, city) = graph[v].Pop();
                    if (!used.Contains(city))
                    {
                        used.Add(city);
                        stack.Push(u);
                        localCities.Add(city);
                    }
                }
                else
                {
                    path.Add(stack.Pop());
                }
            }
            if (localCities.Count > 0 && path.Count > 1 && path[0] == path[path.Count - 1])
            {
                cycleLengths.Add(localCities.Count);
            }
            else if (localCities.Count > 0)
            {
                foreach (var city in localCities)
                {
                    used.Remove(city);
                    char from = city[0];
                    char to = city[city.Length - 1];
                    graph[from].Push((to, city));
                }
                break;
            }
        }

        using (var writer = new StreamWriter("output.txt"))
        {
            writer.WriteLine(cycleLengths.Count);
            foreach (var len in cycleLengths)
                writer.WriteLine(len);
        }
    }
} 