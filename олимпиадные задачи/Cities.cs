// Решение ргр задачи по алгоритмизации и программированию "Города(максимальный путь между любыми городами)"

using System;
using System.IO;

class MaxDistanceBetweenCities
{
    static void Main()
    {
        var input = Console.In;
        var firstLine = input.ReadLine().Split();
        int N = int.Parse(firstLine[0]);
        int M = int.Parse(firstLine[1]);

        int INF = int.MaxValue / 2;
        int[,] dist = new int[N, N];

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                dist[i, j] = (i == j) ? 0 : INF;

        for (int m = 0; m < M; m++)
        {
            var line = input.ReadLine().Split();
            int u = int.Parse(line[0]) - 1;
            int v = int.Parse(line[1]) - 1;
            int l = int.Parse(line[2]);
            if (dist[u, v] > l)
            {
                dist[u, v] = l;
                dist[v, u] = l;
            }
        }

        for (int k = 0; k < N; k++)
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                        dist[i, j] = dist[i, k] + dist[k, j];

        int maxDist = 0;
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                if (i != j && dist[i, j] > maxDist)
                    maxDist = dist[i, j];

        Console.WriteLine(maxDist);
    }
} 