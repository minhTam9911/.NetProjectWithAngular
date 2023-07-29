using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class PolicyTotalDescription
{
    public long Id { get; set; }

    public int Policyid { get; set; }

    public string? Policyname { get; set; }

    public string? Policydesc { get; set; }

    public decimal? Policyamount { get; set; }

    public decimal? Emi { get; set; }

    public int? PolicydurationinMonths { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Medicalname { get; set; }

    public virtual Policy Policy { get; set; } = null!;
}
