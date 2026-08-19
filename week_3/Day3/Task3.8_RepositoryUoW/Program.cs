using System;
using System.Collections.Generic;
using System.Linq;

namespace RepoUoWDemo
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public class StudentRepository : IRepository<Student>
    {
        private readonly List<Student> _students = new();

        public IEnumerable<Student> GetAll() => _students;
        public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);
        public void Add(Student entity) => _students.Add(entity);
        public void Update(Student entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null) existing.Name = entity.Name;
        }
        public void Delete(int id) => _students.RemoveAll(s => s.Id == id);
    }

    public class CourseRepository : IRepository<Course>
    {
        private readonly List<Course> _courses = new();

        public IEnumerable<Course> GetAll() => _courses;
        public Course? GetById(int id) => _courses.FirstOrDefault(c => c.Id == id);
        public void Add(Course entity) => _courses.Add(entity);
        public void Update(Course entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null) existing.Title = entity.Title;
        }
        public void Delete(int id) => _courses.RemoveAll(c => c.Id == id);
    }

    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }
        IRepository<Course> Courses { get; }
        bool Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Student> Students { get; } = new StudentRepository();
        public IRepository<Course> Courses { get; } = new CourseRepository();

        public bool Save()
        {
            Console.WriteLine("[UnitOfWork] Changes committed successfully to database.");
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 3.8: Repository & Unit of Work Seam ===");
            IUnitOfWork uow = new UnitOfWork();

            uow.Students.Add(new Student { Id = 1, Name = "John Doe" });
            uow.Courses.Add(new Course { Id = 101, Title = "Design Patterns in C#" });

            bool saved = uow.Save();
            Console.WriteLine($"Save status: {saved}. Students count: {uow.Students.GetAll().Count()}");
        }
    }
}
