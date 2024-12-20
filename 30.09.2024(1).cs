using System;
class HelloWorld 
{
  static void Main()
  {
    int num, max=0, c=0, y=1, pos;
    num=Convert.ToInt32(Console.ReadLine());
    for (int i=0;i<num;i++)
    {
        pos=Convert.ToInt32(Console.ReadLine());
        if (i!=0 && c==pos)
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
}