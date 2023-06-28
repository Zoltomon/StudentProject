using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class LessonsStudent
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? LessonsId { get; set; }

    public virtual Lesson? Lessons { get; set; }

    public virtual Student? Student { get; set; }
}
