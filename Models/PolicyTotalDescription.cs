using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class PolicyTotalDescription
{
    public int Policyid { get; set; }

    public string? Policyname { get; set; }

    public string? Policydesc { get; set; }

    public decimal? Policyamount { get; set; }

    public decimal? Emi { get; set; }

    public int? PolicydurationinMonths { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Medicalid { get; set; }

    public virtual Policy Policy { get; set; } = null!;
}
