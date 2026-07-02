using System;

namespace Day5Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== PARTIAL CLASS ==========\n");

            Employee employee = new Employee();

            employee.Id = 101;
            employee.Name = "Vamsi";

            employee.ShowEmployee();

            Console.WriteLine();

            Console.WriteLine("========== ACCESS MODIFIERS ==========\n");

            AccessModifierDemo demo = new AccessModifierDemo();

            demo.DisplayAccessModifiers();

            Console.WriteLine();

            Console.WriteLine("========== RECORD ==========\n");

            Address address1 = new Address(
                "MG Road",
                "Hyderabad",
                "500001");

            Address address2 = new Address(
                "MG Road",
                "Hyderabad",
                "500001");

            Console.WriteLine($"Address1 == Address2 : {address1 == address2}");

            Address address3 = address1 with
            {
                City = "Bangalore"
            };

            Console.WriteLine();

            Console.WriteLine("Original Record");

            Console.WriteLine(address1);

            Console.WriteLine();

            Console.WriteLine("Copied Record");

            Console.WriteLine(address3);

            Console.WriteLine();

            Console.WriteLine("========== INDEXER ==========\n");

            Playlist playlist = new Playlist();

            playlist[0] = "Believer";
            playlist[1] = "Perfect";
            playlist[2] = "Shape of You";

            Console.WriteLine(playlist[0]);
            Console.WriteLine(playlist[1]);
            Console.WriteLine(playlist[2]);

            Console.WriteLine();

            Console.WriteLine(playlist[10]);

            Console.WriteLine();

            Console.WriteLine("========== STRING INDEXER ==========\n");

            Console.WriteLine(playlist["Programming", 3]);

            Console.WriteLine(playlist["CSharp", 5]);
        }
    }
}