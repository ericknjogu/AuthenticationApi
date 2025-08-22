using System;
using System.Collections.Generic;

namespace AuthenticationApi.Models;

public partial class EmpDetail
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? InMachine { get; set; }
}
