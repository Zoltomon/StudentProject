using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronomic { get; set; }

    public int CodeTeacher { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();

    public virtual User User { get; set; } = null!;
}
