using System;
class HelloWorld 
{
  static void Main() 
  {
    int num, max=0, c=0, y=0, pos;
    num=Convert.ToInt32(Console.ReadLine());
    for (int i=0;i<num;i++)
    {
        pos=Convert.ToInt32(Console.ReadLine());
        if (pos==0)
        {
          y ++;
        }
            if (y>max)
            {
              max=y;
            }
        c=pos;
    }
    Console.WriteLine(max);
  }
}2