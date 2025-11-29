using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using(var context = new StudentDBContext())
            {
                var students = context.Students
                    .Include(s=>s.Group)
                    .ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"Student: {student.Name}, Group: {student.Group.Name}");
                }
            }

        }
    }
}
