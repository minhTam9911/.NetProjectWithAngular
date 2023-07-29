using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class PolicyApprovalDetail
{
    public int PolicyId { get; set; }

    public int? RequestId { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Amount { get; set; }

    public bool? Status { get; set; }

    public string? Reason { get; set; }

    public virtual Policy Policy { get; set; } = null!;

    public virtual PolicyRequestDetail? Request { get; set; }
}
