using System;

namespace education
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[][] massiving = Inputmassive();
            int[] strocks = Kolvostrok(massiving);

            Console.WriteLine("номера строк с равномерно убывающей последовательностью");
            for (int i = 0; i < strocks.Length; i++)
            {
                if (strocks[i] == 1)
                {
                    Console.WriteLine(strocks[i]);
                }
            }
        }
        static int[][] Inputmassive()
        {
            Console.Write("Введите количество строк зубчатого массива: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] jaggedArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите количество элементов в {i + 1}-ой строке: ");
                int m = Convert.ToInt32(Console.ReadLine());
                jaggedArray[i] = new int[m];

                Console.Write("Введите элементы {i + 1}-ой строки: ");
                for (int j = 0; j<m; j++)
                {
                    jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            return jaggedArray;
        }

        static int[] Kolvostrok(int[][] massive)
        {
            int[] strocks = new int[massive.Length];
            for (int i = 0; i < strocks.Length; i++)
            {
                strocks[i] = -1;
            }
            for (int i = 0; i < massive.Length; i++)
            {
                if (Answer(massive[i]) == 1)
                {
                    strocks[i] = i;
                }
            }
            return strocks;
        }

        static int Answer(int[] array)
        {   
            int K = 1; 
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] >= array[i-1])
                {
                    K=0;
                }
            }
            if (K==1) return 1;
            else return 0;
        }
    }   
}
