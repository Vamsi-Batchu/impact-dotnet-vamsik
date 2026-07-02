//using System;

//namespace Day4Assignment
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("========== VAR EXAMPLE ==========\n");

//            // var is strongly typed.
//            // Compiler decides the type during compilation.

//            var value = 100;

//            Console.WriteLine($"Value : {value}");

//            // Uncomment the below line to see compile-time error.

//            // value = "Hello";

//            /*
//             Compile-time Error:

//             Cannot implicitly convert type 'string' to 'int'

//             Reason:
//             var becomes int because its first value is an int.
//            */

//            Console.WriteLine();

//            Console.WriteLine("========== DYNAMIC EXAMPLE ==========\n");

//            dynamic item = "Hello World";

//            Console.WriteLine($"Value : {item}");
//            Console.WriteLine($"Runtime Type : {item.GetType()}");

//            Console.WriteLine();

//            item = 500;

//            Console.WriteLine($"Value : {item}");
//            Console.WriteLine($"Runtime Type : {item.GetType()}");

//            Console.WriteLine();

//            item = true;

//            Console.WriteLine($"Value : {item}");
//            Console.WriteLine($"Runtime Type : {item.GetType()}");

//            Console.WriteLine();

//            Console.WriteLine("========== DYNAMIC PARAMETER ==========\n");

//            Console.WriteLine(Add(10, 20));

//            Console.WriteLine(Add("Hello ", "World"));
//        }

//        static dynamic Add(dynamic a, dynamic b)
//        {
//            return a + b;
//        }
//    }
//}



using System;

namespace Day4Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //    // -------------------------------
            //    // Task 1: Get Min and Max
            //    // -------------------------------

            //    int[] numbers = { 25, 10, 75, 45, 90, 5 };

            //    var result = GetMinMax(numbers);

            //    Console.WriteLine("Minimum Value : " + result.Min);
            //    Console.WriteLine("Maximum Value : " + result.Max);

            //    Console.WriteLine();

            //    // -------------------------------
            //    // Task 2: Employee Lookup
            //    // -------------------------------

            //    var (Name, Age, Department) = GetEmployeeDetails(101);

            //    Console.WriteLine("Employee Details");
            //    Console.WriteLine("----------------");
            //    Console.WriteLine($"Name       : {Name}");
            //    Console.WriteLine($"Age        : {Age}");
            //    Console.WriteLine($"Department : {Department}");
            //}

            //// Returns Named Tuple
            //static (int Min, int Max) GetMinMax(int[] numbers)
            //{
            //    int min = numbers[0];
            //    int max = numbers[0];

            //    foreach (int number in numbers)
            //    {
            //        if (number < min)
            //            min = number;

            //        if (number > max)
            //            max = number;
            //    }

            //    return (min, max);
            //}

            //// Returns Employee Tuple
            //static (string Name, int Age, string Department) GetEmployeeDetails(int employeeId)
            //{
            //    // Normally this would come from a database

            //    if (employeeId == 101)
            //    {
            //        return ("Vamsi", 24, "Software Development");
            //    }

            //    return ("Unknown", 0, "N/A");
            //}





            //    Console.WriteLine("========== Object Pattern Matching ==========\n");

            //    PrintValue(100);
            //    PrintValue("Hello World");
            //    PrintValue(99.95);
            //    PrintValue(null);

            //    Console.WriteLine();

            //    Console.WriteLine("========== Switch Expression ==========\n");

            //    Console.WriteLine($"Marks : 95  Grade : {CalculateGrade(95)}");
            //    Console.WriteLine($"Marks : 82  Grade : {CalculateGrade(82)}");
            //    Console.WriteLine($"Marks : 68  Grade : {CalculateGrade(68)}");
            //    Console.WriteLine($"Marks : 45  Grade : {CalculateGrade(45)}");

            //    Console.WriteLine();

            //    Console.WriteLine("========== Property Pattern ==========\n");

            //    Order order1 = new Order
            //    {
            //        Status = "Completed",
            //        Amount = 6000
            //    };

            //    Order order2 = new Order
            //    {
            //        Status = "Completed",
            //        Amount = 3000
            //    };

            //    Order order3 = new Order
            //    {
            //        Status = "Pending",
            //        Amount = 7000
            //    };

            //    ApplyDiscount(order1);
            //    ApplyDiscount(order2);
            //    ApplyDiscount(order3);
            //}

            //// Object Pattern Matching
            //static void PrintValue(object value)
            //{
            //    if (value is int number)
            //    {
            //        Console.WriteLine($"Integer Value : {number}");
            //    }
            //    else if (value is string text)
            //    {
            //        Console.WriteLine($"String Value : {text}");
            //    }
            //    else if (value is double decimalValue)
            //    {
            //        Console.WriteLine($"Double Value : {decimalValue}");
            //    }
            //    else if (value is null)
            //    {
            //        Console.WriteLine("Value is Null");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Unknown Type");
            //    }
            //}

            //// Switch Expression with Relational Patterns
            //static string CalculateGrade(int marks)
            //{
            //    return marks switch
            //    {
            //        >= 90 => "A",
            //        >= 75 => "B",
            //        >= 60 => "C",
            //        >= 35 => "D",
            //        _ => "Fail"
            //    };
            //}

            //// Property Pattern
            //static void ApplyDiscount(Order order)
            //{
            //    string message = order switch
            //    {
            //        { Status: "Completed", Amount: >= 5000 }
            //            => "20% Discount Applied",

            //        { Status: "Completed", Amount: < 5000 }
            //            => "10% Discount Applied",

            //        _ => "No Discount"
            //    };

            //    Console.WriteLine(message);





            Console.WriteLine("========== Constructor Chaining ==========\n");

            Student student1 = new Student();

            student1.DisplayStudent();

            Console.WriteLine();

            Student student2 = new Student("Vamsi", 24);

            student2.DisplayStudent();

            Console.WriteLine();

            Console.WriteLine("========== Property Validation ==========\n");

            Student student3 = new Student();

            student3.Age = 150;

            Console.WriteLine();

            Console.WriteLine("========== Method Overloading ==========\n");

            student2.CalculateGrade(92);

            student2.CalculateGrade(84.5);

            Console.WriteLine();

            Console.WriteLine("========== const vs readonly ==========\n");

            Console.WriteLine($"School Name : {Student.SchoolName}");

            Console.WriteLine($"Admission Date : {student2.AdmissionDate}");

            // Uncomment to see compile-time errors

            // Student.SchoolName = "XYZ School";
            // Error:
            // The left-hand side of an assignment must be a variable, property or indexer

            // student2.AdmissionDate = DateTime.Now;
            // Error:
            // Init-only/readonly field cannot be assigned outside the constructor.
        }

    }
}