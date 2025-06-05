using System;
struct Book
{
    public string Author;
    public string Title;
    public int PublicationYear;
    public string Publisher;
}
struct Form
{
    public string NameBook;
    public DateTime IssueDate;
    public DateTime? ReturnDate;
}
class Library
{
    List<Book> books = new List<Book>();
    List<Form> forms = new List<Form>();
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    public void DisplayBookInfo(Book book)
    {
        Console.WriteLine($"\nАвтор книги: {book.Author}");
        Console.WriteLine($"Название книги: {book.Title}");
        Console.WriteLine($"Год выпуска: {book.PublicationYear}");
        Console.WriteLine($"Издательство: {book.Publisher}");
    }
    public void DisplayAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Библиотека пуста.");
        }
        else
        {
            Console.WriteLine("Список всех книг: ");
            foreach (var book in books)
            {
                DisplayBookInfo(book);
            }
        }
    }
    public void IssueBook(string nameBook, DateTime issueDate)
    {
        bool exist = false;
        foreach (var book in books)
        {
            if (book.Title == nameBook)
            {
                exist = true;
                break;
            }
        }
        if (!exist)
        {
            Console.WriteLine($"Книга '{nameBook}' не найдена");
            return;
        }
        forms.Add(new Form { NameBook = nameBook, IssueDate = issueDate, ReturnDate = null });
        Console.WriteLine($"Книга '{nameBook}' выдана");
    }
    public void ReturnBook(string nameBook, DateTime returnDate)
    {
        bool found = false;
        for (int i = 0; i < forms.Count; i++)
        {
            if (forms[i].NameBook == nameBook && forms[i].ReturnDate == null)
            {
                var newForm = forms[i];
                newForm.ReturnDate = returnDate;
                forms[i] = newForm;
                Console.WriteLine($"Книга '{nameBook}' вернулась в библиотеку.");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Книга '{nameBook}' не найдена.");
        }
    }
    public void ListNeverIssuedBooks()
    {
        Console.WriteLine("\nСписок книг, которые никогда не выдавались: ");
        bool found = false;
        for (int i = 0;i < books.Count;i++)
        {
            bool issued = false;
            foreach (var form in forms)
            {
                if (form.NameBook == books[i].Title)
                {
                    issued = true;
                    break;
                }
            }
            if (!issued)
            {
                DisplayBookInfo(books[i]);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Все книги были когда-то выданы");
        }
    }
    public void ListBooksOnLoan()
    {
        bool found = false;
        Console.WriteLine("\nСписок выданных книг: ");
        for (int i = 0; i < books.Count; i++)
        {
            foreach (var form in forms)
            {
                if (form.ReturnDate == null)
                {
                    if (form.NameBook == books[i].Title)
                    {
                        DisplayBookInfo(books[i]);
                        found = true;
                    }
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Выданых книг нету");
        }
    }
}

class Program
{
    static void AddNewBookFromConsole(Library library)
    {
        Book book = new Book();
        Console.WriteLine("\nВведите автора книги: ");
        book.Author = Console.ReadLine();
        Console.WriteLine("Введите название книги: ");
        book.Title = Console.ReadLine();
        Console.WriteLine("Введите год выпуска книги: ");
        book.PublicationYear = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите наименование издательства книги: ");
        book.Publisher = Console.ReadLine();
        library.AddBook(book);
    }
    static void IssueBookFromConsole(Library library)
    {
        Console.WriteLine("\nВведите название книги которую хотите выдать: ");
        string nameBook = Console.ReadLine();
        Console.WriteLine("Введите дату выдачи книги: ");
        DateTime issueDate = DateTime.Parse(Console.ReadLine());
        library.IssueBook(nameBook, issueDate);
    }
    static void ReturnBookFromConsole(Library library)
    {
        Console.WriteLine("\nВведите название кники, которую хотите вернуть: ");
        string bookName = Console.ReadLine();
        Console.WriteLine("Введите дату сдачи книги: ");
        DateTime returnDate = DateTime.Parse(Console.ReadLine());
        library.ReturnBook(bookName, returnDate);
    }
    static void Main()
    {
        Library library = new Library();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n1. Добавить новую книгу");
            Console.WriteLine("2. Выдать книгу читателю");
            Console.WriteLine("3. Вернуть книгу в библиотеку");
            Console.WriteLine("4. Показать все книги");
            Console.WriteLine("5. Показать книги, которые никогда не выдавались");
            Console.WriteLine("6. Показать книги, которые сейчас на руках");
            Console.WriteLine("7. Выйти из программы");
            Console.Write("\nВыберите действие: ");

            int menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    AddNewBookFromConsole(library);
                    break;
                case 2:
                    IssueBookFromConsole(library);
                    break;
                case 3:
                    ReturnBookFromConsole(library);
                    break;
                case 4:
                    library.DisplayAllBooks();
                    break;
                case 5:
                    library.ListNeverIssuedBooks();
                    break;
                case 6:
                    library.ListBooksOnLoan();
                    break;
                case 7:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("\nНеверный выбор. Введите число от 1 до 7.");
                    break;
            }
        }
    }
}