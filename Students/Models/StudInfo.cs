using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    internal class StudInfo
    {
        public int Id { get; set; }
        public string? Login { get; set; }

        public string? HashPassword { get; set; }

        public Student? Student { get; set; }

    }
}
