using System;
class HelloWorld 
{
  static void Main() 
  {
    int i, x=0, kolvo;
    Console.WriteLine("Количество чисел в массиве: ");
    kolvo=Convert.ToInt32(Console.ReadLine());
    int[] num = new int[kolvo];
    Console.WriteLine("Числа в массиве: ");
    for (i=0;i<kolvo;i++)
    {
        num[i] = Convert.ToInt32(Console.ReadLine());
    }
    for (i=0;i<kolvo;i++)
    {
        if (num[i]%10==3 || Math.Abs(num[i])%10==3)
        {
            x++;
        }
    }
    Console.WriteLine("Результат: ");
    Console.WriteLine(x);
  }
}