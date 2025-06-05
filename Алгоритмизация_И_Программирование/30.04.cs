using System;
using System.Linq;
using System.Collections.Generic;

class Phone
{
    public string PhoneNumber { get; set; }
    public string FullName { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Operator { get; set; }

    public Phone(string phoneNumber, string fullName, DateTime registrationDate, string operatorName)
    {
        PhoneNumber = phoneNumber;
        FullName = fullName;
        RegistrationDate = registrationDate;
        Operator = operatorName;
    }
}

class Program
{
    static void InputPhoneData(List<Phone> phoneList, int numberOfOwners)
    {
        for (int i = 0; i < numberOfOwners; i++)
        {
            Console.WriteLine($"\nВведите номер телефона {i + 1}-го владельца: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine($"Введите ФИО {i + 1}-го владельца: ");
            string fullName = Console.ReadLine();
            Console.WriteLine($"Введите дату постановки на учет {i + 1}-го владельца (дд.мм.гггг): ");
            DateTime registrationDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine($"Введите оператора связи {i + 1}-го владельца: ");
            string operatorName = Console.ReadLine();
            Phone newPhone = new Phone(phoneNumber, fullName, registrationDate, operatorName);
            phoneList.Add(newPhone);
        }
    }

    static void Main()
    {
        bool isRunning = true;
        List<Phone> phoneList = new List<Phone>();

        while (isRunning)
        {
            Console.WriteLine("\n1. Заполнить данные.");
            Console.WriteLine("2. Выборка по ФИО.");
            Console.WriteLine("3. Выборка по номеру телефона.");
            Console.WriteLine("4. Вывести данные сгруппированные по году.");
            Console.WriteLine("5. Вывести данные сгруппированные по оператору.");
            Console.WriteLine("6. Выход.");
            Console.WriteLine("Введите операцию, которую хотите сделать: ");

            int menuChoice;
            if (!int.TryParse(Console.ReadLine(), out menuChoice))
            {
                Console.WriteLine("\nНекорректный ввод. Пожалуйста, введите число.");
                continue;
            }

            switch (menuChoice)
            {
                case 1:
                    Console.WriteLine("\nВведите количество владельцев.");
                    int numberOfOwners;
                    if (!int.TryParse(Console.ReadLine(), out numberOfOwners))
                    {
                        Console.WriteLine("\nНекорректный ввод. Пожалуйста, введите число.");
                        continue;
                    }
                    InputPhoneData(phoneList, numberOfOwners);
                    break;

                case 2:
                    Console.WriteLine("\nВведите ФИО для выборки: ");
                    string searchName = Console.ReadLine();
                    var phonesByName = from phone in phoneList
                                       where phone.FullName == searchName
                                       select phone;
                    foreach (var phone in phonesByName)
                    {
                        Console.WriteLine($"\nНомер: {phone.PhoneNumber}, ФИО: {phone.FullName}, Дата: {phone.RegistrationDate.ToShortDateString()}, Оператор: {phone.Operator}");
                    }
                    break;

                case 3:
                    Console.WriteLine("\nВведите номер телефона для выборки: ");
                    string searchNumber = Console.ReadLine();
                    var phonesByNumber = from phone in phoneList
                                         where phone.PhoneNumber == searchNumber
                                         select phone;
                    foreach (var phone in phonesByNumber)
                    {
                        Console.WriteLine($"Номер: {phone.PhoneNumber}, ФИО: {phone.FullName}, Дата: {phone.RegistrationDate.ToShortDateString()}, Оператор: {phone.Operator}");
                    }
                    break;

                case 4:
                    Console.WriteLine("\nГруппировка по году: ");
                    var phonesGroupedByYear = from phone in phoneList
                                              group phone by phone.RegistrationDate.Year into g
                                              orderby g.Key
                                              select g;

                    foreach (var group in phonesGroupedByYear)
                    {
                        Console.WriteLine($"\nГод: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"Номер: {phone.PhoneNumber}, ФИО: {phone.FullName}, Дата: {phone.RegistrationDate.ToShortDateString()}, Оператор: {phone.Operator}");
                        }
                    }
                    break;

                case 5:
                    Console.WriteLine("\nГруппировка по оператору: ");
                    var phonesGroupedByOperator = from phone in phoneList
                                                  group phone by phone.Operator into g
                                                  orderby g.Key
                                                  select g;
                    foreach (var group in phonesGroupedByOperator)
                    {
                        Console.WriteLine($"\nОператор: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"Номер: {phone.PhoneNumber}, ФИО: {phone.FullName}, Дата: {phone.RegistrationDate.ToShortDateString()}");
                        }
                    }
                    break;

                case 6:
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("\nТакой операции не существует.");
                    break;
            }
        }
    }
}