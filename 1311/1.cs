using System;
using System.Collections.Generic;

public class Book : IComparable<Book>, ICloneable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public int CompareTo(Book other)
    {
        return Year.CompareTo(other.Year);
    }

    public object Clone()
    {
        return new Book(Title, Author, Year);
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, {Year}";
    }
}

public class BookTitleComparer : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        return string.Compare(x.Title, y.Title, StringComparison.OrdinalIgnoreCase);
    }
}

class Program
{
    static void Main()
    {
        var books = new List<Book>
        {
            new Book("1984", "George Orwell", 1949),
            new Book("Brave New World", "Aldous Huxley", 1932),
            new Book("Fahrenheit 451", "Ray Bradbury", 1953)
        };

        Console.WriteLine("Original list:");
        books.ForEach(book => Console.WriteLine(book));

        books.Sort();
        Console.WriteLine("\nSorted by year:");
        books.ForEach(book => Console.WriteLine(book));

        books.Sort(new BookTitleComparer());
        Console.WriteLine("\nSorted by title:");
        books.ForEach(book => Console.WriteLine(book));

        var clone = (Book)books[0].Clone();
        Console.WriteLine("\nCloned book:");
        Console.WriteLine(clone);
    }
}