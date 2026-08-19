using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Genre { get; set; } = "";
    public int Year { get; set; }
    public bool IsAvailable { get; set; }
}

public static class Program
{
    static List<Book> GetBooks() => new()
    {
        new() { Title="The Hobbit", Author="J.R.R. Tolkien", Genre="Fantasy", Year=1937, IsAvailable=true },
        new() { Title="1984", Author="George Orwell", Genre="Dystopian", Year=1949, IsAvailable=true },
        new() { Title="Animal Farm", Author="George Orwell", Genre="Dystopian", Year=1945, IsAvailable=false },
        new() { Title="Clean Code", Author="Robert C. Martin", Genre="Technology", Year=2008, IsAvailable=true },
        new() { Title="The Pragmatic Programmer", Author="Andrew Hunt", Genre="Technology", Year=1999, IsAvailable=true },
        new() { Title="Dune", Author="Frank Herbert", Genre="Science Fiction", Year=1965, IsAvailable=false },
        new() { Title="Foundation", Author="Isaac Asimov", Genre="Science Fiction", Year=1951, IsAvailable=true },
        new() { Title="Harry Potter and the Sorcerer's Stone", Author="J.K. Rowling", Genre="Fantasy", Year=1997, IsAvailable=true },
        new() { Title="The Name of the Wind", Author="Patrick Rothfuss", Genre="Fantasy", Year=2007, IsAvailable=false },
        new() { Title="The Martian", Author="Andy Weir", Genre="Science Fiction", Year=2011, IsAvailable=true },
        new() { Title="Project Hail Mary", Author="Andy Weir", Genre="Science Fiction", Year=2021, IsAvailable=true },
        new() { Title="Atomic Habits", Author="James Clear", Genre="Self Help", Year=2018, IsAvailable=true },
        new() { Title="Deep Work", Author="Cal Newport", Genre="Self Help", Year=2016, IsAvailable=false },
        new() { Title="The Alchemist", Author="Paulo Coelho", Genre="Fiction", Year=1988, IsAvailable=true },
        new() { Title="Sapiens", Author="Yuval Noah Harari", Genre="History", Year=2011, IsAvailable=true },
        new() { Title="Educated", Author="Tara Westover", Genre="Memoir", Year=2018, IsAvailable=true }
    };

    public static void Main()
    {
        var books = GetBooks();

        Console.WriteLine("1. Available books by author:");
        var availableByAuthor = books
            .Where(b => b.IsAvailable)
            .OrderBy(b => b.Author)
            .ThenBy(b => b.Title);

        foreach (var book in availableByAuthor)
            Console.WriteLine($"{book.Author} - {book.Title}");

        Console.WriteLine("\n2. Group by genre with count:");
        var byGenre = books
            .GroupBy(b => b.Genre)
            .OrderBy(g => g.Key);

        foreach (var group in byGenre)
            Console.WriteLine($"{group.Key}: {group.Count()}");

        Console.WriteLine("\n3. Oldest book:");
        var oldest = books.OrderBy(b => b.Year).First();
        Console.WriteLine($"{oldest.Title} ({oldest.Year})");

        Console.WriteLine("\n4. Books after 2010 sorted by title:");
        var after2010 = books
            .Where(b => b.Year > 2010)
            .OrderBy(b => b.Title);

        foreach (var book in after2010)
            Console.WriteLine($"{book.Title} - {book.Year}");
    }
}
