

public interface ILibrary
{
    public Book[] books { get; set; }

    public int LengthOfLibrary { get; }

    public void SortLibrary();
    public void AddBook(Book book);
    public void DeleteBook(int book_id);

    public Book this[int index] { get; set; }
    public void ShowLibrary();
    public int FindBookById(int book_id);
}



public class Library : ILibrary
{
    public Book[] books { get; set; }
    public bool LibraryStatus = false;

    public int LengthOfLibrary
    {
        get => books.Length;
    }

    public Library(Book[] books)
    {
        this.books = books;
        SortLibrary();
        Message.Print("Welcome to the library!");
        Message.Print("You can check out, add and remove books from the library.");
        Message.Print("Enter 1 to enter.");
        bool IsSignValid = int.TryParse(System.Console.ReadLine(), out int antw);
        if (antw == 1)
        {
            System.Console.Clear();
            LibraryStatus = true;
        }
        else
        {
            Message.Print("Access denied");
        }
        
    }

    public Book this[int index]
    {
        get => books[index];
        set => books[index] = value;
    }

    public void SortLibrary()
    {
        for (int i = 0; i < books.Length; i++)
        {
            for (int j = i + 1; j < books.Length; j++)
            {
                if (books[i].CompareTo(books[j]) > 0)
                {
                    var temp = books[i];
                    books[i] = books[j];
                    books[j] = temp;
                }
            }
        }
    }

    public void AddBook(Book book) // Add book to a Library
    {
        Book[] temp = new Book[books.Length + 1];
        for (int i = 0; i < books.Length; i++)
        {
            temp[i] = books[i];
        }
        temp[books.Length] = book;
        books = temp;
        SortLibrary();
        Message.Print("The book has been successfully added to the library");

    }

    public void DeleteBook(int book_id) // Delete book from Library
    {
        int indx = FindBookById(book_id);

        if (indx == -1)
        {
            Message.Print("Books was not found!");
        }
        else
        {
            Book[] temp = new Book[books.Length - 1];
            for (int i = 0; i < books.Length; i++)
            {
                if (i == indx)
                {
                    continue;
                }
                temp[i] = books[i];
            }
            books = temp;
            Message.Print("The book was successfully deleted");
        }
    }
    
    public int FindBookById(int book_id)
        {
            int left = 0;
            int right = books.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (books[mid].Id == book_id)
                {
                    return mid; // books was found
                }
                else if (books[mid].Id < book_id)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

    public void ShowLibrary()
    {
        Message.Print("=====");

        foreach (Book book in books)
        {
            System.Console.WriteLine($"{book.Title} by {book.Autor} in {book.Year}. ID:({book.Id})");
        }

        Message.Print("=====");
    }
}