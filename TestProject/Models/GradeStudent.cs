using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class GradeStudent
{
    public int Id { get; set; }

    public double? ScaleGrade { get; set; }

    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }
}
