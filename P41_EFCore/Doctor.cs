using System;
using System.Collections.Generic;

namespace DB_First;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Surname { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<DoctorsExamination> DoctorsExaminations { get; set; } = new List<DoctorsExamination>();

    public virtual ICollection<Inter> Inters { get; set; } = new List<Inter>();

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();

    public override string ToString()
    {
        return $"{Name.PadRight(20)} {Surname.PadRight(20)}, Salary: {Salary}, Deleted: {IsDeleted}";
    }
}
