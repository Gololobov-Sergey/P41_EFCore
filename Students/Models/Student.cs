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
        //[ForeignKey("GroupId987")]
        public Group? Group { get; set; }


        public int? StudInfoId { get; set; }
        public StudInfo? StudInfo { get; set; }


        //public List<Subject>? Subjects { get; set; }

        public List<StudentSubject>? StudentSubjects { get; set; }


        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName}, born on {DateOfBirth.ToShortDateString()}, Group: {Group?.Name}, Login: {StudInfo?.Login}, HashPassword: {StudInfo?.HashPassword}";
        }
    }
}
