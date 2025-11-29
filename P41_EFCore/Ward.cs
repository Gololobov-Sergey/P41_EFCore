using System;
using System.Collections.Generic;

namespace DB_First;

public partial class Ward
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Places { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<DoctorsExamination> DoctorsExaminations { get; set; } = new List<DoctorsExamination>();
}
