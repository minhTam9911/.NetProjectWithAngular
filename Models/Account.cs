using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class Account
{
    public string Role { get; set; } = null;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;


    public string Email { get; set; } = null!;


}
