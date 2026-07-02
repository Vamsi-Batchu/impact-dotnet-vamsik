using Day3Assignment;
using System;

namespace Day3Assignment
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("========== VALUE TYPE ==========");

            //int number1 = 10;
            //int number2 = number1;

            //number2 = 50;

            //Console.WriteLine($"number1 = {number1}");
            //Console.WriteLine($"number2 = {number2}");

            ///*
            //number1 stays 10 because int is a value type.
            //Copying creates an independent copy.
            //*/

            //Console.WriteLine();


            //Console.WriteLine("========== ARRAY ==========");

            //int[] arr1 = { 10, 20, 30 };

            //int[] arr2 = arr1;

            //arr2[0] = 999;

            //Console.WriteLine(arr1[0]);
            //Console.WriteLine(arr2[0]);

            ///*
            //Arrays are reference types.

            //Both arr1 and arr2 point to the same object.
            //Changing one changes the other.
            //*/


            //Console.WriteLine("========== STRUCT ==========");

            //CoordinateStruct point1 = new CoordinateStruct();

            //point1.X = 10;
            //point1.Y = 20;

            //CoordinateStruct point2 = point1;

            //point2.X = 100;

            //Console.WriteLine(point1.X);
            //Console.WriteLine(point2.X);

            ///*
            //Struct is a value type.

            //Copying creates another independent object.
            //*/


            //Console.WriteLine("========== CLASS ==========");

            //CoordinateClass obj1 = new CoordinateClass();

            //obj1.X = 10;
            //obj1.Y = 20;

            //CoordinateClass obj2 = obj1;

            //obj2.X = 500;

            //Console.WriteLine(obj1.X);
            //Console.WriteLine(obj2.X);

            ///*
            //Class is a reference type.

            //Both variables refer to the same object.

            //Changing obj2 also changes obj1.
            //*/


            //1.10


            //Console.Write("Enter a number (0-6): ");

            //int dayNumber = Convert.ToInt32(Console.ReadLine());

            //DaysOfWeek day = (DaysOfWeek)dayNumber;

            //Console.WriteLine(day);




            // 1.11


            //        int? number = null;

            //        Console.WriteLine("Nullable Integer");

            //        Console.WriteLine($"Has Value : {number.HasValue}");

            //        Console.WriteLine();

            //        number = 100;

            //        Console.WriteLine($"Has Value : {number.HasValue}");

            //        Console.WriteLine($"Value : {number.Value}");

            //        Console.WriteLine();

            //        Console.WriteLine("Discount Examples");

            //        ApplyDiscount(null);

            //        ApplyDiscount(20);
            //    }

            //    static void ApplyDiscount(double? discount)
            //    {
            //        double finalDiscount = discount ?? 5;

            //        Console.WriteLine($"Discount Applied : {finalDiscount}%");
            //}


            //1.12

            Console.WriteLine("Implicit Conversion");

            int number = 100;

            long longNumber = number;

            float floatNumber = longNumber;

            double doubleNumber = floatNumber;

            Console.WriteLine(number);
            Console.WriteLine(longNumber);
            Console.WriteLine(floatNumber);
            Console.WriteLine(doubleNumber);

            Console.WriteLine();

            Console.WriteLine("Explicit Conversion");

            double price = 99.99;

            int wholeNumber = (int)price;

            Console.WriteLine(wholeNumber);

            // Decimal part is lost during explicit conversion.

            Console.WriteLine();

            Console.WriteLine("is Operator");

            object obj = "Hello";

            Console.WriteLine(obj is string);

            Console.WriteLine(obj is int);

            Console.WriteLine();

            Console.WriteLine("as Operator");

            object name = "Vamsi";

            string text = name as string;

            Console.WriteLine(text);

            Console.WriteLine();

            Console.WriteLine("Convert.ToInt32");

            string value = "123";

            int convertedValue = Convert.ToInt32(value);

            Console.WriteLine(convertedValue);

            Console.WriteLine();

            Console.WriteLine("TryParse");

            string input = "456";

            bool success = int.TryParse(input, out int result);

            Console.WriteLine($"Success : {success}");

            Console.WriteLine($"Result : {result}");

            input = "ABC";

            success = int.TryParse(input, out result);

            Console.WriteLine($"Success : {success}");

            Console.WriteLine($"Result : {result}");

        }
    }
}