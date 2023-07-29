using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class Account
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SecurityCode { get; set; }

    public bool? Status { get; set; }

    public string? Role { get; set; }
}
