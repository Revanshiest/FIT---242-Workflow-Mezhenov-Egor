// Решение ргр задачи по алгоритмизации и программированию "Супер конь"

using System;
using System.Collections.Generic;
using System.IO;

class SuperKnight
{
    static readonly int[] knightDx = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static readonly int[] knightDy = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static readonly int[] whiteDx = { 1, -1, 0, 0 };
    static readonly int[] whiteDy = { 0, 0, 1, -1 };

    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        int N = int.Parse(lines[0]);
        string[] parts = lines[1].Split(' ');
        int x1 = int.Parse(parts[0]);
        int y1 = int.Parse(parts[1]);
        int x2 = int.Parse(parts[2]);
        int y2 = int.Parse(parts[3]);

        int result = BFS(N, x1, y1, x2, y2);
        File.WriteAllText("output.txt", result == -1 ? "NO" : result.ToString());
    }

    static int BFS(int N, int x1, int y1, int x2, int y2)
    {
        var queue = new Queue<(int x, int y, int dist)>();
        var visited = new bool[N + 1, N + 1];
        queue.Enqueue((x1, y1, 0));
        visited[x1, y1] = true;

        while (queue.Count > 0)
        {
            var (x, y, dist) = queue.Dequeue();
            if (x == x2 && y == y2)
                return dist;

            bool isBlack = ((x + y) % 2 == 0);
            if (isBlack)
            {
                for (int i = 0; i < 8; i++)
                {
                    int nx = x + knightDx[i];
                    int ny = y + knightDy[i];
                    if (nx >= 1 && nx <= N && ny >= 1 && ny <= N && !visited[nx, ny])
                    {
                        visited[nx, ny] = true;
                        queue.Enqueue((nx, ny, dist + 1));
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    int nx = x + whiteDx[i];
                    int ny = y + whiteDy[i];
                    if (nx >= 1 && nx <= N && ny >= 1 && ny <= N && !visited[nx, ny])
                    {
                        visited[nx, ny] = true;
                        queue.Enqueue((nx, ny, dist + 1));
                    }
                }
            }
        }
        return -1;
    }
} 