using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Assignment
{
    public class Student
    {
        // const field (must be assigned at declaration)
        public const string SchoolName = "ABC Public School";

        // readonly field (can only be assigned at declaration or constructor)
        public readonly DateTime AdmissionDate;

        // Private fields
        private string _name;
        private int _age;

        // Validated Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 5 && value <= 100)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Invalid Age! Age must be between 5 and 100.");
                }
            }
        }

        // Default Constructor
        public Student() : this("Unknown", 5)
        {
        }

        // Parameterized Constructor
        public Student(string name, int age)
        {
            Name = name;
            Age = age;

            // readonly field can be assigned here
            AdmissionDate = DateTime.Now;
        }

        // Method Overloading
        public void CalculateGrade(int marks)
        {
            if (marks >= 90)
                Console.WriteLine("Grade : A");
            else if (marks >= 75)
                Console.WriteLine("Grade : B");
            else if (marks >= 60)
                Console.WriteLine("Grade : C");
            else
                Console.WriteLine("Grade : D");
        }

        public void CalculateGrade(double percentage)
        {
            if (percentage >= 90)
                Console.WriteLine("Grade : A");
            else if (percentage >= 75)
                Console.WriteLine("Grade : B");
            else if (percentage >= 60)
                Console.WriteLine("Grade : C");
            else
                Console.WriteLine("Grade : D");
        }

        public void DisplayStudent()
        {
            Console.WriteLine($"Name            : {Name}");
            Console.WriteLine($"Age             : {Age}");
            Console.WriteLine($"School          : {SchoolName}");
            Console.WriteLine($"Admission Date  : {AdmissionDate}");
        }
    }
}