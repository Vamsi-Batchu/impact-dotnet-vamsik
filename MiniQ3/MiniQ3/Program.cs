using MiniQ3;
using System;

namespace MiniQ3
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactCard[] contacts = new ContactCard[5];

            contacts[0] = new ContactCard
            {
                Name = "Vamsi",
                PhoneNumber = "9876543210",
                Email = "vamsi@gmail.com"
            };

            contacts[1] = new ContactCard
            {
                Name = "Rahul",
                PhoneNumber = "9876501234",
                Email = "rahul@gmail.com"
            };

            contacts[2] = new ContactCard
            {
                Name = "Anusha",
                PhoneNumber = "9876512345",
                Email = "anusha@gmail.com"
            };

            contacts[3] = new ContactCard
            {
                Name = "Kiran",
                PhoneNumber = "9876523456",
                Email = "kiran@gmail.com"
            };

            contacts[4] = new ContactCard
            {
                Name = "Priya",
                PhoneNumber = "9876534567",
                Email = "priya@gmail.com"
            };

            Console.Write("Enter name to search : ");

            string searchName = Console.ReadLine();

            bool found = false;

            foreach (ContactCard contact in contacts)
            {
                if (contact.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine();
                    Console.WriteLine("Contact Found");
                    Console.WriteLine($"Name  : {contact.Name}");
                    Console.WriteLine($"Phone : {contact.PhoneNumber}");
                    Console.WriteLine($"Email : {contact.Email}");

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Contact Not Found");
            }
        }
    }
}