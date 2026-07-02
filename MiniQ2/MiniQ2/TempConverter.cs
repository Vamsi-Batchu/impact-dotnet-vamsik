using System;

namespace MiniQ2
{
    public class TemperatureConverter
    {
        // Celsius
        public void Convert(double celsius)
        {
            double fahrenheit = (celsius * 9 / 5) + 32;
            double kelvin = celsius + 273.15;

            Console.WriteLine($"Celsius : {celsius}");
            Console.WriteLine($"Fahrenheit : {fahrenheit}");
            Console.WriteLine($"Kelvin : {kelvin}");
        }

        // Fahrenheit
        public void Convert(int fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5.0 / 9;
            double kelvin = celsius + 273.15;

            Console.WriteLine($"Fahrenheit : {fahrenheit}");
            Console.WriteLine($"Celsius : {celsius}");
            Console.WriteLine($"Kelvin : {kelvin}");
        }

        // Kelvin
        public void Convert(float kelvin)
        {
            double celsius = kelvin - 273.15;
            double fahrenheit = (celsius * 9 / 5) + 32;

            Console.WriteLine($"Kelvin : {kelvin}");
            Console.WriteLine($"Celsius : {celsius}");
            Console.WriteLine($"Fahrenheit : {fahrenheit}");
        }
    }
}