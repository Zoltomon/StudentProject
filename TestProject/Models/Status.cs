using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Status
{
    public int Id { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
