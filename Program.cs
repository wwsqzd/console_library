using System.Data.Common;


Library mainLib = new Library(new List<Book> {new Book(2, "Tree of Smoke", "Denis Johnson", 2007), new Book(1, "How to Be Both", "Ali Smith", 2014)});



void Commands()
{
    System.Console.ForegroundColor = ConsoleColor.Red;
    System.Console.WriteLine("---> Enter 1 to display the array");
    System.Console.WriteLine("---> Enter 2 to add a book to the library");
    System.Console.WriteLine("---> Enter 3 to remove a book from the library");
    System.Console.WriteLine("---> Enter 0 to terminate the program");
    System.Console.ResetColor();
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
        Message.Print("Library display");
        mainLib.ShowLibrary();
    }
    else if (Convert.ToInt32(ant) == 2)
    {
        int temp_id;
        while (true)
        {
            Message.Print("Enter the unique ID of the book:");
            bool IsIdValid = int.TryParse(System.Console.ReadLine(), out int tp_id);
            if (IsIdValid)
            {
                Book? ifcont = mainLib.FindBookById(tp_id);
                if (ifcont == null)
                {
                    temp_id = tp_id;
                    break;
                }
                else
                {
                    Message.Print("Such an ID already exists. Enter a different one");
                    continue;
                }
            }
            else
            {
                Message.Print("Enter the correct number!");
                continue;
            }
        }


        Message.Print("Type in the title of the book:");
        string? temp_title = System.Console.ReadLine();
        Message.Print("Enter the author of the book:");
        string? temp_autor = System.Console.ReadLine();
        Message.Print("Enter the year of the book:");
        bool IsYearValid = int.TryParse(System.Console.ReadLine(), out int temp_year);
        if (!string.IsNullOrWhiteSpace(temp_title) && !string.IsNullOrWhiteSpace(temp_autor) && IsYearValid)
        {
            await mainLib.AddBook(new Book(temp_id, temp_title, temp_autor, temp_year));
        }
        else
        {
            Message.Print("Incorrect data entry");
        }
    }
    else if (Convert.ToInt32(ant) == 3)
    {
        Message.Print("Write the book ID");
        bool IsIdValid = int.TryParse(System.Console.ReadLine(), out int tp_id);
        if (IsIdValid)
        {
            mainLib.DeleteBook(tp_id);
        }
        else
        {
            Message.Print("Incorrect data entry");   
        }
        
    }

}
// Book book1 = new Book("Tree of Smoke", "Denis Johnson", 2007);
// Book book2 = new Book("How to Be Both", "Ali Smith", 2014);
// Book book3 = new Book("Bel Canto", "Ann Patchett", 2001);
// Book book4 = new Book("Men We Reaped", "Jesmyn Ward", 2013);
// Book book5 = new Book("Wayward Lives, Beautiful Experiments", "Saidiya Hartman", 2019);
// books Example
