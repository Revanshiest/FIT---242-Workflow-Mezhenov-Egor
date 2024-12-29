using System;
class Student
{
    public string Name {get; set;}
    public int Year {get; set;}
    public string Curse {get; set;}
    public Student(string name, int year, string curse)
    {
        Name = name;
        Year = year;
        Curse = curse;
    }
}

class Program 
{       
    static Student[] zapoln(Student[] students)
    {
        for(int i = 0; i < students.Length; i++)
        {
            Console.WriteLine($"Имя {i+1} ученика:  ");
            string name = Console.ReadLine();
            
            Console.WriteLine($"Год рождения {name}:  ");
            int year = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine($"Курс {name}:  ");
            string curse = Console.ReadLine();

            students[i] = new Student(name, year, curse);

        }
        return students;
    }

    static void poisk_po_godu(Student[] students)
    {
        Console.WriteLine("Введите год рождения:  ");
        int year = Convert.ToInt32(Console.ReadLine());
        for(int i = 0; i < students.Length; i++)
        {
            if (students[i].Year == year)
            {
                Console.WriteLine($"Имя: {students[i].Name}, Курс: {students[i].Curse}");
            }
        }
    }

    static void poisk_po_kurse(Student[] students)
    {
        Console.WriteLine("Введите курс:  ");
        string curse = Console.ReadLine();
        for(int i = 0; i < students.Length; i++)
        {
            if (students[i].Curse == curse)
            {
                Console.WriteLine($"Имя: {students[i].Name}, год рождения: {students[i].Year}");
            }
        }
    }
    
    static void inform(Student[] student)
    {
        for (int i = 0; i < student.Length; i++)
        {
            Console.WriteLine($"{i+1}. Имя: {student[i].Name}, Год рождения: {student[i].Year}, Курс: {student[i].Curse}");
        }
    }   
    static void modifyStudent(Student[] students)
    {
        inform(students);
        Console.WriteLine("выберите студента для измения");
        int number = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine("Введите новое имя:");
        string name = Console.ReadLine();
        students[number].Name = name;

        Console.WriteLine($"Введите новый год рождения: {name}");
        students[number].Year = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine($"Введите новый курс: {name}");
        students[number].Curse = Console.ReadLine();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество учеников:  ");
        int caount = Convert.ToInt32(Console.ReadLine());
        Student[] students = new Student[caount];
        
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Заполнение информации о студентах");
            Console.WriteLine("2. Поиск по году");
            Console.WriteLine("3. Поиск по курсу");
            Console.WriteLine("4. Модификация");
            Console.WriteLine("5. Выход");
            int vibor = Convert.ToInt32(Console.ReadLine());
            switch (vibor) 
            {
                case 1:
                    zapoln(students);
                    break;

                case 2:

                poisk_po_godu(students);
                
                break;
                case 3:

                poisk_po_kurse(students);

                break;

                case 4:
                
                modifyStudent(students);

                break;

                case 5:
                Console.WriteLine("окончание программы");
                return;

            }
        }
    }
}
