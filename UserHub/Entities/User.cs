using System;
using System.Collections.Generic;

namespace UserHub.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Names { get; set; } = null!;

    public string? Surnames { get; set; }

    public string? IdNumber { get; set; }

    public DateTime? LastSessionDate { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
