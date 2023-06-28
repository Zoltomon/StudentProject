using System;
using System.Collections.Generic;

namespace TestWebAPI.Models;

public partial class LoginHistory
{
    public int Id { get; set; }

    public TimeOnly TimeAuto { get; set; }

    public TimeOnly TimeExit { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
