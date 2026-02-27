using System;
using System.Collections.Generic;

namespace CSI402.Models.Db;

public partial class LabStudent
{
    public string StdId { get; set; } = null!;

    public string? StdPassword { get; set; }

    public string? StdName { get; set; }

    public string? StdLastname { get; set; }
}
