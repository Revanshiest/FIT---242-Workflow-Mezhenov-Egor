using System;
class HelloWorld 
{
  static void Main() 
  {
    int i, last=0, kolvo;
    Console.WriteLine("Количество чисел в массиве: ");
    kolvo=Convert.ToInt32(Console.ReadLine());
    int[] num = new int[kolvo];
    Console.WriteLine("Числа в массиве: ");
    for (i=0;i<kolvo;i++)
    {
        num[i] = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("Результат: ");
    for (i=0;i<kolvo;i++)
    {
        int sum=0;
        int nomer = Math.Abs(num[i]);
        while (nomer>0)
        {
            sum+=nomer%10;
            nomer/=10;
        }
        Console.WriteLine(sum);
    }
  }
}