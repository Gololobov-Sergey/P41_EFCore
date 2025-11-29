using System;
using System.Collections.Generic;

namespace DB_First;

public partial class DoctorsExamination
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int DiseaseId { get; set; }

    public int DoctorId { get; set; }

    public int ExaminationId { get; set; }

    public int WardId { get; set; }

    public virtual Disease Disease { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Examination Examination { get; set; } = null!;

    public virtual Ward Ward { get; set; } = null!;
}
