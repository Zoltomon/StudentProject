using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Group
{
    public int Id { get; set; }

    public string? NameGroup { get; set; }

    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
}
