﻿using Project_ASP.Net_And_Angular.Models;

namespace Project_ASP.Net_And_Angular.Services;

public interface IPolicyRequest
{
    int create(PolicyRequestDetail policyRequestDetail);
    dynamic get();
    dynamic findById(int id);
    bool update(PolicyRequestDetail policyRequestDetail);
    bool delete(int id);
    dynamic findByColEmpNo(int id);
}
