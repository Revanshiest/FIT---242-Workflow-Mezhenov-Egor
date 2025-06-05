using System;
using System.IO;
class Program
{
    static void Main()
    {
        string inputFilePath = @"input.txt";
        string outputFilePath = @"output.txt";

        string[] allLines = File.ReadAllLines(inputFilePath);
        List<string> linesWithEvenNumbers = new List<string>();

        for (int i = 0; i < allLines.Length; i++)
        {
            string currentLine = allLines[i];
            string currentNumberString = "";

            for (int j = 0; j < currentLine.Length; j++)
            {
                char currentChar = currentLine[j];

                if (char.IsDigit(currentChar))
                {
                    currentNumberString += currentChar;
                }
                else
                {
                    if (currentNumberString.Length != 0)
                    {
                        if (int.Parse(currentNumberString) % 2 == 0)
                        {
                            linesWithEvenNumbers.Add(currentLine);
                            currentNumberString = "";
                            break;
                        }
                        currentNumberString = "";
                    }
                }
            }

            if (currentNumberString.Length != 0)
            {
                if (int.Parse(currentNumberString) % 2 == 0)
                {
                    linesWithEvenNumbers.Add(currentLine);
                }
            }
        }
        File.WriteAllLines(outputFilePath, linesWithEvenNumbers);
    }
}