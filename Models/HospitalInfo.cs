using System;
using System.Collections.Generic;

namespace Project_ASP.Net_And_Angular.Models;

public partial class HospitalInfo
{
    public long HospitalId { get; set; }

    public string? HospitalName { get; set; }

    public string? PhoneNo { get; set; }

    public string? Location { get; set; }

    public string? Url { get; set; }
}
