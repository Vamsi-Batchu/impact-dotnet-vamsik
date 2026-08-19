using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public string Title { get; }
    public Book(string title) => Title = title;
}

public class BookCollection : IEnumerable<Book>
{
    private readonly List<Book> books;

    public BookCollection(IEnumerable<Book> books)
    {
        this.books = books.ToList();
    }

    public IEnumerator<Book> GetEnumerator()
    {
        foreach (var book in books.OrderBy(b => b.Title))
        {
            Console.WriteLine($"Yielding: {book.Title}");
            yield return book;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public static class Program
{
    static IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 0; i <= max; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine($"Producing {i}");
                yield return i;
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("Even numbers:");
        foreach (var number in GetEvenNumbers(10))
            Console.WriteLine($"Consumed {number}");

        Console.WriteLine("\nBooks are consumed lazily:");
        var collection = new BookCollection(new[]
        {
            new Book("Clean Code"),
            new Book("C# in Depth"),
            new Book("Algorithms")
        });

        foreach (var book in collection)
            Console.WriteLine($"Consumed book: {book.Title}");
    }
}
