using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    //[Table("Bublik")]
    internal class Student
    {
        //[Column("stud_id")]
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string? FirstName { get; set; }
        //[Required]
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }


        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName}, born on {DateOfBirth.ToShortDateString()}";
        }
    }
}
