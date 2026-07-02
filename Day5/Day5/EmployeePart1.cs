using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Assignment
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        partial void DisplayEmployeeMessage();

        public void ShowEmployee()
        {
            Console.WriteLine($"Employee ID   : {Id}");
            Console.WriteLine($"Employee Name : {Name}");

            DisplayEmployeeMessage();
        }
    }
}
