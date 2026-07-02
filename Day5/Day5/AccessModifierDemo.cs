using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Assignment
{
    public class AccessModifierDemo
    {
        public string PublicValue = "Public";

        private string PrivateValue = "Private";

        protected string ProtectedValue = "Protected";

        internal string InternalValue = "Internal";

        protected internal string ProtectedInternalValue = "Protected Internal";

        private protected string PrivateProtectedValue = "Private Protected";

        public void DisplayAccessModifiers()
        {
            Console.WriteLine($"Public               : {PublicValue}");
            Console.WriteLine($"Private              : {PrivateValue}");
            Console.WriteLine($"Protected            : {ProtectedValue}");
            Console.WriteLine($"Internal             : {InternalValue}");
            Console.WriteLine($"Protected Internal   : {ProtectedInternalValue}");
            Console.WriteLine($"Private Protected    : {PrivateProtectedValue}");
        }
    }
}