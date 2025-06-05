using System;
using System.Runtime.Serialization.Formatters;

class Program
{
    static bool IsPalindrome(int number)
    {
        int originalNumber = number;
        int reversedNumber = 0;
        while (number > 0)
        {
            reversedNumber = reversedNumber * 10 + number % 10;
            number /= 10;
        }
        return reversedNumber == originalNumber;
    }

    static unsafe void Main()
    {
        int arraySize = 6;
        int* numberArray = stackalloc int[arraySize];
        numberArray[0] = 121;
        numberArray[1] = 1221;
        numberArray[2] = 23;
        numberArray[3] = 1;
        numberArray[4] = 555;
        numberArray[5] = 566;

        for (int i = 0; i < arraySize; i++)
        {
            if (IsPalindrome(numberArray[i]))
            {
                Console.WriteLine(numberArray[i]);
            }
        }
    }
}