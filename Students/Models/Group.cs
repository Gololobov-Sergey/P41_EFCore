using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    
    internal class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[NotMapped]
        public int Rating { get; set; }


        public List<Student> Students { get; set; }
    }
}
