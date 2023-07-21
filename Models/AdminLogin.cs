using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class AdminLogin
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SecurityCode { get; set; }
}
