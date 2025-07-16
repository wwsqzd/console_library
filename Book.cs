
interface IBook : IComparable, ICloneable
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Autor { get; set; }
    public int Year { get; set; }
}


public class Book : IBook
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Autor { get; set; }
    public int Year { get; set; }

    public Book(int id, string title, string autor, int year)
    {
        Id = id;
        Title = title;
        Autor = autor;
        Year = year;
    }

    public object Clone()
    {
        return new Book(Id, Title, Autor, Year);
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