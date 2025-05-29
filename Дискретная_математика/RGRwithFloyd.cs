using System;
using System.IO;

class Program
{
    static void Main()
    {
        static void Floyd(int[,] graph, int N)
    {
        for (int k = 0; k < N; k++)
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (graph[i, k] + graph[k, j] < graph[i, j])
                        graph[i, j] = graph[i, k] + graph[k, j];
    }

        Console.WriteLine("Введите имя файла: ");
        string filename = Console.ReadLine();
        string[] lines = File.ReadAllLines(filename);

        int N = int.Parse(lines[0]);
        int M = int.Parse(lines[1]);

        int INF = int.MaxValue / 2;
        int[,] graph = new int[N, N];

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                graph[i, j] = (i == j) ? 0 : INF; // Я правда так умею) это тернарный оператор

        for (int i = 0; i < M; i++)
        {
            string[] parts = lines[2 + i].Split();
            int u = int.Parse(parts[0]) - 1;
            int v = int.Parse(parts[1]) - 1;
            int w = int.Parse(parts[2]);
            graph[u, v] = w;
            graph[v, u] = w;
        }

        Floyd(graph, N);

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i == j) continue;
                if (graph[i, j] == INF)
                    Console.WriteLine($"{i + 1} {j + 1} -1");
                else
                    Console.WriteLine($"{i + 1} {j + 1} {graph[i, j]}");
            }
        }
    }
} 