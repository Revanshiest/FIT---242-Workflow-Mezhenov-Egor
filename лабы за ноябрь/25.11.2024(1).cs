using System;
class Program
{
    static void Main()
    {
        string res = "";
        int max = 0;
        string n = Console.ReadLine();
        int[] count = new int[256];
        for (int i = 0; i < n.Length - 1; i++)
        {
            if (n[i] == 'a' || n[i] == 'A')
            {
                for (int j = i + 1; j < n.Length; j++)
                {
                    if (n[j] == 'b' || n[j] == 'B')
                    {
                        for (int k = i + 1; k < j; k++)
                        {
                            count[n[k]]++;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < count.Length; i++)
        {
            if (count[i] > max)
            {
                max = count[i];
                res = ((char)i).ToString(); 
            }
        }
        Console.WriteLine(res);
    }
}