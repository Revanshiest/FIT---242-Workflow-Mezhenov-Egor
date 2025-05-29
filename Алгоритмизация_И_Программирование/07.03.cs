using System;
class Phone
{
    public string Number { get; set; }
    public string Name { get; set; }
    public string Operator { get; set; }
    public Phone(string number, string name, string oper)
    {
        Number = number;
        Name = name;
        Operator = oper;
    }
}
class Programa
{
    static void Main()
    {
        List<Phone> Phones = new List<Phone>();

        Dictionary<string, int> operators = new Dictionary<string, int>();
        foreach (var s in Phones)
        {
            if (operators.ContainsKey(s.Operator))
            {
                operators[s.Operator]++;
            }
            else
            {
                operators[s.Operator] = 1;
            }
        }
        Console.WriteLine("Количество операторов");
        foreach (var oper in operators)
        {
            Console.WriteLine(oper);
        }
    }
}