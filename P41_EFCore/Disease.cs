using System;
using System.Collections.Generic;

namespace DB_First;

public partial class Disease
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DoctorsExamination> DoctorsExaminations { get; set; } = new List<DoctorsExamination>();
}
