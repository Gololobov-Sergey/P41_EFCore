using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    internal class StudentSubject
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public int CountLectures { get; set; }
    }
}
