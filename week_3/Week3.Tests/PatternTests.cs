using System;
using System.Collections.Generic;

using Xunit;
using ExceptionsDemo;
using AsyncDemo;
using SingletonDemo;
using FactoryDemo;
using StrategyDemo;
using RepoUoWDemo;
using InterfaceVsAbstractDemo;
using SortingDemo;

namespace Week3.Tests
{
    public class PatternTests
    {
        // Strategy Pattern Tests
        [Fact]
        public void Strategy_RuntimeSwap_ChangesBehavior()
        {
            var cart = new ShoppingCart();
            
            cart.SetPaymentStrategy(new CreditCardPayment("1234567890123456"));
            var res1 = cart.Checkout(100);
            Assert.Contains("Credit Card", res1);

            cart.SetPaymentStrategy(new UpiPayment("test@upi"));
            var res2 = cart.Checkout(100);
            Assert.Contains("UPI", res2);
        }

        // Factory Pattern Tests
        [Theory]
        [InlineData("car", typeof(Car))]
        [InlineData("bike", typeof(Bike))]
        [InlineData("truck", typeof(Truck))]
        public void Factory_CreatesCorrectType(string type, Type expectedType)
        {
            var vehicle = VehicleFactory.CreateVehicle(type);
            Assert.IsType(expectedType, vehicle);
        }

        [Fact]
        public void Factory_UnknownType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => VehicleFactory.CreateVehicle("plane"));
        }

        // Singleton Pattern Test
        [Fact]
        public void Singleton_ReturnsSameInstanceAcrossCalls()
        {
            var instance1 = Logger.Instance;
            var instance2 = Logger.Instance;
            Assert.Same(instance1, instance2);
        }

        // Repository & Unit of Work Tests
        [Fact]
        public void RepositoryAndUoW_CRUDAndSave_WorksAsExpected()
        {
            IUnitOfWork uow = new UnitOfWork();
            uow.Students.Add(new Student { Id = 1, Name = "Alice" });

            var student = uow.Students.GetById(1);
            Assert.NotNull(student);
            Assert.Equal("Alice", student.Name);

            bool saved = uow.Save();
            Assert.True(saved);
        }

        // MathHelper Static Methods Tests
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(5, 120)]
        public void MathHelper_Factorial_CalculatesCorrectly(int input, long expected)
        {
            Assert.Equal(expected, MathHelper.Factorial(input));
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(17, true)]
        [InlineData(4, false)]
        [InlineData(1, false)]
        public void MathHelper_IsPrime_ValidatesCorrectly(int number, bool expected)
        {
            Assert.Equal(expected, MathHelper.IsPrime(number));
        }

        // Sorting Tests
        [Fact]
        public void Sorting_IComparable_SortsBySalary()
        {
            var list = new List<Employee>
            {
                new Employee { Name = "A", Salary = 200 },
                new Employee { Name = "B", Salary = 100 }
            };

            list.Sort();
            Assert.Equal(100, list[0].Salary);
        }

        [Fact]
        public void Sorting_IComparer_SortsByName()
        {
            var list = new List<Employee>
            {
                new Employee { Name = "Zack", Salary = 200 },
                new Employee { Name = "Adam", Salary = 100 }
            };

            list.Sort(new EmployeeNameComparer());
            Assert.Equal("Adam", list[0].Name);
        }
    }
}
