using System;
using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        foreach (var book in books)
        {
            yield return book;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        var library = new Library();
        library.AddBook(new Book("1984", "George Orwell", 1949));
        library.AddBook(new Book("Brave New World", "Aldous Huxley", 1932));
        library.AddBook(new Book("Fahrenheit 451", "Ray Bradbury", 1953));

        Console.WriteLine("Library books:");
        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
    }
}