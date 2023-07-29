using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class PolicyRequestDetail
{
    public int RequestId { get; set; }

    public DateTime? RequestDate { get; set; }

    public int Empno { get; set; }

    public int? PolicyId { get; set; }

    public string? Policyname { get; set; }

    public decimal? PolicyAmount { get; set; }

    public decimal? Emi { get; set; }

    public int? CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public string? Status { get; set; }

    public virtual EmpRegister EmpnoNavigation { get; set; } = null!;

    public virtual ICollection<PolicyApprovalDetail> PolicyApprovalDetails { get; set; } = new List<PolicyApprovalDetail>();
}
