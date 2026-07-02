using MiniQ2;
using System;

namespace MiniQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            TemperatureConverter converter = new TemperatureConverter();

            converter.Convert(25.0);

            Console.WriteLine();

            converter.Convert(98);

            Console.WriteLine();

            converter.Convert(300f);
        }
    }
}