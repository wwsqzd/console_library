using System.Data.Common;


Library mainLib = new Library(new Book[0]);

void Commands() {
    System.Console.WriteLine("---> Введите 1 чтоб вывести массив");
    System.Console.WriteLine("---> Введите 2 чтобы добавить книгу в библиотеку");
    System.Console.WriteLine("---> Введите 3 чтобы удалить книгу из библиотеки");
    System.Console.WriteLine("---> Введите 0 чтоб завершить программу");
}

while (mainLib.LibraryStatus)
{
    Commands();
    string? ant = System.Console.ReadLine();

    if (Convert.ToInt32(ant) == 0)
    {
        mainLib.LibraryStatus = false;
    }
    else if (Convert.ToInt32(ant) == 1)
    {
        mainLib.ShowLibrary();
    }
    else if (Convert.ToInt32(ant) == 2)
    {
        int temp_id;
        while (true)
        {
            System.Console.WriteLine("Ввведите уникальное ID книги:");
            bool IsIdValid = int.TryParse(System.Console.ReadLine(), out int tp_id);
            if (IsIdValid)
            {
                if (mainLib.FindBookById(tp_id) == -1)
                {
                    temp_id = tp_id;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Такой ID уже существует. Введите другой");
                    continue;
                }
            }
            else
            {
                System.Console.WriteLine("Введите коректно число!");
                continue;
            }
        }


        System.Console.WriteLine("Ввведите название книги:");
        string? temp_title = System.Console.ReadLine();
        System.Console.WriteLine("Ввведите автора книги:");
        string? temp_autor = System.Console.ReadLine();
        System.Console.WriteLine("Ввведите год книги:");
        bool IsYearValid = int.TryParse(System.Console.ReadLine(), out int temp_year);
        if (!string.IsNullOrWhiteSpace(temp_title) && !string.IsNullOrWhiteSpace(temp_autor) && IsYearValid)
        {
            mainLib.AddBook(new Book(temp_id, temp_title, temp_autor, temp_year));
        }
        else
        {
            System.Console.WriteLine("Incorrect data entry");
        }
    }
    else if (Convert.ToInt32(ant) == 3)
    {
        System.Console.WriteLine("Write the book ID");
        bool IsIdValid = int.TryParse(System.Console.ReadLine(), out int tp_id);
        if (IsIdValid)
        {
            mainLib.DeleteBook(tp_id);
        }
        else
        {
            System.Console.WriteLine("Incorrect data entry");   
        }
        
    }

}
// Book book1 = new Book("Tree of Smoke", "Denis Johnson", 2007);
// Book book2 = new Book("How to Be Both", "Ali Smith", 2014);
// Book book3 = new Book("Bel Canto", "Ann Patchett", 2001);
// Book book4 = new Book("Men We Reaped", "Jesmyn Ward", 2013);
// Book book5 = new Book("Wayward Lives, Beautiful Experiments", "Saidiya Hartman", 2019);
// books Example
