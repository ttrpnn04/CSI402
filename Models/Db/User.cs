using System;
using System.Collections.Generic;

namespace CSI402.Models.Db;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; }
    
    public string Lastname { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
