// Решение ргр задачи по алгоритмизации и программированию "Расстояние между городами(на планете)"

using System;
using System.Globalization;
using System.IO;

class Program
{
    static void Main()
    {
        string[] line1 = File.ReadAllLines("Input.txt")[0].Split();
        string[] line2 = File.ReadAllLines("Input.txt")[1].Split();
        int S1 = int.Parse(line1[0]);
        int D1 = int.Parse(line1[1]);
        int S2 = int.Parse(line2[0]);
        int D2 = int.Parse(line2[1]);
        int R = int.Parse(File.ReadAllLines("Input.txt")[2]);

        double phi1 = S1 * Math.PI / 180.0;
        double phi2 = S2 * Math.PI / 180.0;
        int deltaD = Math.Abs(D1 - D2);
        if (deltaD > 180) deltaD = 360 - deltaD;
        double deltaLambda = deltaD * Math.PI / 180.0;

        double cosSigma = Math.Sin(phi1) * Math.Sin(phi2) +
                          Math.Cos(phi1) * Math.Cos(phi2) * Math.Cos(deltaLambda);

        cosSigma = Math.Min(1.0, Math.Max(-1.0, cosSigma));
        double sigma = Math.Acos(cosSigma);

        double distance = R * sigma;

        File.WriteAllText("Output.txt", distance.ToString("F3"));
    }
} 