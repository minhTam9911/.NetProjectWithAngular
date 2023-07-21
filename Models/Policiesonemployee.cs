﻿using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class Policiesonemployee
{
    public int Empno { get; set; }

    public int Policyid { get; set; }

    public string Policyname { get; set; } = null!;

    public decimal Policyamount { get; set; }

    public decimal Policyduration { get; set; }

    public decimal Emi { get; set; }

    public int Companyid { get; set; }

    public string Companyname { get; set; } = null!;

    public string Medical { get; set; } = null!;

    public virtual EmpRegister EmpnoNavigation { get; set; } = null!;

    public virtual Policy Policy { get; set; } = null!;
}
