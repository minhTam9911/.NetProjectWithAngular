using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class EmpRegister
{
    public int Empno { get; set; }

    public string? Designation { get; set; }

    public DateTime? Joindate { get; set; }

    public decimal? Salary { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public string? Contactno { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Rolename { get; set; }

    public bool? AccountStatus { get; set; }

    public string? SecurityCode { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<PoliciesonEmployee> PoliciesonEmployees { get; set; } = new List<PoliciesonEmployee>();

    public virtual ICollection<PolicyRequestDetail> PolicyRequestDetails { get; set; } = new List<PolicyRequestDetail>();
}
