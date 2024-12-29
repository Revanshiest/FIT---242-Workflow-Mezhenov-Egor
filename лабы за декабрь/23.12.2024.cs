using System;
class People
{
    public string Name { get; set; }
    public int Year { get; set; }
    public People(string name, int year)
    {
        Name = name;
        Year = year;
    }
    public virtual void PrintInfo()
    {
        Console.WriteLine($"ФИО: {Name}, Год рождения: {Year}");
    }
}
class Student : People
{
    public int[] Mark { get; set; }
    public Student(string name, int year, int[] mark) : base(name, year) 
    {
        Mark = mark;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Оценки: {string.Join(", ", Mark)}");
    }
}
class Teacher : People
{
    public string[] Lesson { get; set; }
    public Teacher(string name, int year, string[] lesson) : base(name, year)
    {
        Lesson = lesson;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Предметы: {string.Join(", ", Lesson)}");
    }
}
class Program
{
    static void ZapolnStudent(Student[] student)
    {
        for (int i = 0; i < student.Length; i++)
        {
            Console.WriteLine($"\nВведите ФИО студента под номером {i + 1}");
            string name = Console.ReadLine();

            Console.WriteLine("Введите год рождения студента");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество оценок студента");
            int countMark = int.Parse(Console.ReadLine());
            var mark = new int[countMark];

            Console.WriteLine("Введите оценки студента");
            for (int j = 0; j < countMark; j++)
            {
                mark[j] = int.Parse(Console.ReadLine());
            }
            student[i] = new Student(name, year, mark);
        }
    }
    static void ZapolnTeacher(Teacher[] teacher)
    {
        for (int i = 0; i < teacher.Length; i++)
        {
            Console.WriteLine($"\nВведите ФИО преподавателя под номером {i + 1}");
            string name = Console.ReadLine();

            Console.WriteLine("Введите год рождения преподавателя");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество дисциплин преподавателя");
            int countSubject = int.Parse(Console.ReadLine());
            var subject = new string[countSubject];

            Console.WriteLine("Введите дисциплины преподавателя");
            for (int j = 0; j < countSubject; j++)
            {
                subject[j] = Console.ReadLine();
            }
            teacher[i] = new Teacher(name, year, subject);
        }
    }
    static void ViborYear(Student[] student)
    {
        Console.WriteLine("\nВведите год рождения студента");
        int year = int.Parse(Console.ReadLine());
        int kolvo = 0;

        for (int i = 0;i < student.Length;i++)
        {
            if (year == student[i].Year)
            {
                student[i].PrintInfo(); ;
                kolvo++;
            }
        }
        if (kolvo == 0)
        {
            Console.WriteLine("Студенты не найдены");
        }
    }
    static void ViborSub(Teacher[] teacher)
    {
        Console.WriteLine("\nВыберите дисциплину");
        string lesson = Console.ReadLine();
        int kolvo = 0;

        for (int i = 0; i < teacher.Length;i++)
        {
            foreach (var subj in teacher[i].Lesson)
            {
                if (subj.Equals(lesson))
                {
                    teacher[i].PrintInfo();
                    kolvo++;
                }
            }
        }
        if (kolvo == 0)
        {
            Console.WriteLine("Преподаватели не найдены");
        }
    }
    public static void Main()
    {
        Console.WriteLine("Введите количество преподавателей");
        int countTeacher = int.Parse(Console.ReadLine());
        Teacher[] teacher = new Teacher[countTeacher];

        Console.WriteLine("Введите количество студентов");
        int countStudent = int.Parse(Console.ReadLine());
        Student[] student = new Student[countStudent];

        bool a = true;
        while (a)
        {
            Console.WriteLine("\n" + "\tМеню");
            Console.WriteLine("1. Заполнение");
            Console.WriteLine("2. Печать данных");
            Console.WriteLine("3. Выбор студентов по году рождения");
            Console.WriteLine("4. Выбор преподавателей по дисциплине");
            Console.WriteLine("5. Выход");

            int vibor = int.Parse(Console.ReadLine());

            if (vibor == 1)
            {
                Console.WriteLine("\n1. Заполнить данные студента");
                Console.WriteLine("2. Заполнить данные преподавателя");

                int vibor2 = int.Parse(Console.ReadLine());

                if (vibor2 == 1)
                {
                    ZapolnStudent(student);
                }
                else if (vibor2 == 2)
                {
                    ZapolnTeacher(teacher);
                }
                else
                {
                    Console.WriteLine("Такой операции не существует");
                }
            }
            else if (vibor == 2)
            {
                Console.WriteLine("\n1. Печать данных о студентах");
                Console.WriteLine("2. Печать данных о преподавателях");

                int vibor2 = int.Parse(Console.ReadLine());

                if (vibor2 == 1)
                {
                    Console.WriteLine("\nСтуденты: ");
                    for (int i = 0; i < countStudent; i++)
                    {
                        student[i].PrintInfo();
                    }
                }
                else if (vibor2 == 2)
                {
                    Console.WriteLine("\nПреподаватели: ");
                    for (int i = 0; i < countTeacher; i++)
                    {
                        teacher[i].PrintInfo();
                    }
                }
                else
                {
                    Console.WriteLine("Такой операции не существует");
                }
            }
            else if (vibor == 3)
            {
                ViborYear(student);
            }
            else if (vibor == 4)
            {
                ViborSub(teacher);
            }
            else if (vibor == 5)
            {
                a = false;
                break;
            }
            else
            {
                Console.WriteLine("Такой операции не существует");
            }
        }
    }
}