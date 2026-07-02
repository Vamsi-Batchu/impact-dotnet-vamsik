#define TRIAL_VERSION
using System;
using SchoolManagement;



namespace Day2Assignment

{

    class Program
    {
        static void Main(string[] args)
        {
            // Task 1.5
            Student student = new Student();
            student.Display();

            SchoolManagement.Student student2 = new SchoolManagement.Student();
            student2.Display();

            // Difference:
            // Using directive lets us reference Student directly.
            // Without using, the full namespace must be specified.

            // Task 1.6
            ModuleA.Helper.Greet();
            ModuleB.Helper.Greet();

            // Task 1.7
            int studentAge = 20;
            string studentName = "Vamsi Krishna";
            double studentMarks = 90.5;
            bool isPassed = true;
            char section = 'A';

            // string class = "CSE"; // Error: 'class' is a reserved keyword
            string @class = "CSE";
            Console.WriteLine($"HI My name is {studentName}, i am from the class of {@class} and my age is {studentAge}");

            // Task 1.8
            #if TRIAL_VERSION
            Console.WriteLine("Running Trial Version");
            #else
            Console.WriteLine("Running Full Version");
            #endif
        }
    }
}