using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronomic { get; set; }

    public int CodeStudent { get; set; }

    public int DirectionOfStudentId { get; set; }

    public int StatusStudentId { get; set; }

    public virtual DirectionOfStudent DirectionOfStudent { get; set; } = null!;

    public virtual ICollection<GradeStudent> GradeStudents { get; set; } = new List<GradeStudent>();

    public virtual ICollection<LessonsStudent> LessonsStudents { get; set; } = new List<LessonsStudent>();

    public virtual StatusStudent StatusStudent { get; set; } = null!;

    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
}
