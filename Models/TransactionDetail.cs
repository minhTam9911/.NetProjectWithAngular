﻿using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class TransactionDetail
{
    public int TransId { get; set; }

    public int AccId { get; set; }

    public decimal TransMoney { get; set; }

    public int TransType { get; set; }

    public DateTime DateOfTrans { get; set; }

    public virtual Account Acc { get; set; } = null!;
}
