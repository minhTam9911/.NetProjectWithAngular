using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class Policy
{
    public int Policyid { get; set; }

    public string? Policyname { get; set; }

    public string? Policydesc { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Emi { get; set; }

    public int? Companyid { get; set; }

    public string? Medicalid { get; set; }

    public virtual CompanyDetail? Company { get; set; }

    public virtual PolicyApprovalDetail? PolicyApprovalDetail { get; set; }
}
