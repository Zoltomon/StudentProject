using System;
using System.Collections.Generic;

namespace TestWebAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int StatusId { get; set; }

    public string IdentificateCode { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();

    public virtual Status Status { get; set; } = null!;
}
