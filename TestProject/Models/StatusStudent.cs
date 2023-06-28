using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class StatusStudent
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
