namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentDBContext())
            {
                var students = db.Students.ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
