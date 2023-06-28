using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? NameSubject { get; set; }

    public virtual ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();

    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
