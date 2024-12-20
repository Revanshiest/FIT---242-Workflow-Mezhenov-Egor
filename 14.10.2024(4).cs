using System;
class HelloWorld 
{
  static void Main() 
  {
    int kolvo, nomer=0,arifmet=0, x=0, sum=0;
    Console.WriteLine("Количество чисел в массиве: ");
    kolvo=Convert.ToInt32(Console.ReadLine());
    int[] num = new int[kolvo];
    Console.WriteLine("Числа в массиве: ");
    for (int i=0;i<kolvo;i++)
    {
        num[i] = Convert.ToInt32(Console.ReadLine());
    }
    for (int i=0;i<kolvo;i++)
    {
        nomer = Math.Abs(num[i]);
        if (nomer%2==0)
        {
            x++;
        }
    }
    for (int i=0;i<kolvo;i++)
    {
        if (num[i]%2==0)
        {
            sum+=num[i];
        }
    }
    if (x>0)
    {
        arifmet = sum / x;
        Console.WriteLine("Результат: ");
        Console.WriteLine(arifmet);
    }
    else
    {
        Console.WriteLine("Четных нет");    
    }
  }
}