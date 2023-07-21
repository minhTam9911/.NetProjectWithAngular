using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class CompanyDetail
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? CompanyUrl { get; set; }

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();
}
