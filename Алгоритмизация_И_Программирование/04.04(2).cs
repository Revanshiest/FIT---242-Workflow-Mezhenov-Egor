using System;
delegate List<string> Lyam(List<string> words);
class Program
{
    static void Main()
    {
        List<string> words = new List<string>()
        {
            "арарат",
            "кайрат",
            "аристократ",
            "Анивия",
            "грация"
        };
        Lyam lyam = list => list.FindAll(word => word[0] == 'а');
        List<string> result = lyam(words);
        Console.WriteLine($"Слова начинающиеся на 'а': ");
        foreach (string word in result)
        {
            Console.WriteLine(word);
        }
    }
}