namespace CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using(var context = new StudentDBContext())
            {
                var students = context.Students.ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }

        }
    }
}
