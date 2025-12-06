using Microsoft.EntityFrameworkCore;
using Students.Models;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentDBContext())
            {

                //Group gr = new Group { Name = "Math 101", Rating = 5 };

                //Student student1 = new Student { FirstName = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(2003, 5, 1), Group = gr};

                //db.Students.Add(student1);
                //db.SaveChanges();



                var students = db.Students
                    .Include(s => s.Group)
                    .Include(s => s.StudInfo)
                    .ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
