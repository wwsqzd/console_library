
interface IBook : IComparable, ICloneable
{
    
}


public class Book(int Id, string Title, string Author, int Year) : IBook
{
    public int Id { get; set; } = Id;
    public string Title { get; set; } = Title;
    public string Author { get; set; } = Author;
    public int Year { get; set; } = Year;


    public object Clone()
    {
        return new Book(Id, Title, Author, Year);
    }

    public int CompareTo(object? obj)
    {
        if (obj is Book other) return this.Id.CompareTo(other.Id);
        else throw new ArgumentException("Object is not a Book");
    }

    

    public static bool operator >(Book book1, Book book2)
    {
        return book1.Year > book2.Year;
    }

    public static bool operator <(Book book1, Book book2)
    {
        return book1.Year < book2.Year;
    }



    public static bool operator true(Book book1)
    {
        return book1.Year != 0;
    }
    public static bool operator false(Book book1)
    {
        return book1.Year == 0;
    }
}