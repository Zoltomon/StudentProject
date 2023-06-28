using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class DirectionOfStudent
{
    public int Id { get; set; }

    public string? NameDirection { get; set; }

    public string? CodeDirection { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
