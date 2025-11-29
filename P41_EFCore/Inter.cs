using System;
using System.Collections.Generic;

namespace DB_First;

public partial class Inter
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;
}
