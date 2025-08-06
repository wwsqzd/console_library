

public interface ILibrary
{
    public List<Book> books { get; set; }

    public int LengthOfLibrary { get; }

    public void SortLibrary();
    public Task AddBook(Book book);
    public void DeleteBook(int book_id);

    public Book this[int index] { get; set; }
    public void ShowLibrary();
    // public int FindBookById(int book_id);
}



public class Library : ILibrary
{
    public List<Book> books { get; set; }
    public bool LibraryStatus = false;

    public int LengthOfLibrary
    {
        get => books.Count;
    }

    public Library(List<Book> books)
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
        books.Sort();
    }

    public async Task AddBook(Book book) // Add book to a Library
    {
        System.Console.WriteLine("Adding a book to your library...");
        books.Add(book);
        SortLibrary();
        await Task.Delay(3000);
        Message.Print("The book has been successfully added to the library");

    }

    public void DeleteBook(int book_id) // Delete book from Library
    {
        Book? bookToRemove = books.FirstOrDefault(b => b.Id == book_id);

        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Message.Print("Books was removed!");
        }
        else
        {
            Message.Print("Books was not found!");
        }
    }
    
    public Book? FindBookById(int book_id)
        {
            return books.Find(b => b.Id == book_id);
        }

    public void ShowLibrary()
    {
        Message.Print("=====");

        foreach (Book book in books)
        {
            System.Console.WriteLine($"{book.Title} by {book.Author} in {book.Year}. ID:({book.Id})");
        }

        Message.Print("=====");
    }
}