using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class TransactionDetail
{
    public int TransactionId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public int? EmpNo { get; set; }

    public int? PolicyEmployeeId { get; set; }

    public int? AccountantId { get; set; }
}
