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
        if (i!=0 && num[i]>num[i - 1])
        {
            x++;
        }
    }    
    Console.WriteLine("Результат: ");
    if (x==kolvo - 1)
    {
        Console.WriteLine("Да");
    }
    else
    {
        Console.WriteLine("Нет");
    }
  }
}