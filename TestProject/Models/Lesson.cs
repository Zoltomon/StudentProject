using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string? NameLessons { get; set; }

    public virtual ICollection<LessonsStudent> LessonsStudents { get; set; } = new List<LessonsStudent>();
}
