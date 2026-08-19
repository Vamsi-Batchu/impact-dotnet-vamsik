using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T> where T : class, new()
{
    private readonly List<T> items = new();

    public void Add(T item) => items.Add(item);

    public void Update(T oldItem, T newItem)
    {
        int index = items.IndexOf(oldItem);
        if (index >= 0)
            items[index] = newItem;
    }

    public void Delete(T item) => items.Remove(item);

    public List<T> GetAll() => new(items);

    /*
     * where T : class, new()
     *
     * class -> T must be a reference type.
     * new()   -> T must have a public parameterless constructor.
     *
     * Together these constraints allow the repository to work with
     * reference types that can be instantiated with new T().
     */
}

public class Student
{
    public string Name { get; set; } = "";
}

public class Product
{
    public string Name { get; set; } = "";
}

public static class Program
{
    public static void Main()
    {
        var studentRepo = new Repository<Student>();
        studentRepo.Add(new Student { Name = "Alice" });
        studentRepo.Add(new Student { Name = "Bob" });

        var productRepo = new Repository<Product>();
        productRepo.Add(new Product { Name = "Laptop" });
        productRepo.Add(new Product { Name = "Mouse" });

        Console.WriteLine("Students:");
        foreach (var student in studentRepo.GetAll())
            Console.WriteLine(student.Name);

        Console.WriteLine("\nProducts:");
        foreach (var product in productRepo.GetAll())
            Console.WriteLine(product.Name);
    }
}
