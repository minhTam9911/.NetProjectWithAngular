using Microsoft.AspNetCore.Http.HttpResults;
using Project_ASP.Net_And_Angular.Models;

namespace Project_ASP.Net_And_Angular.Services;

public interface IPolicyApproval
{
    bool create(PolicyApprovalDetail policyApproval);
    dynamic get();
    dynamic findById(int id);
    bool update(PolicyApprovalDetail policyApproval);
    bool delete(int id);
    bool deleteByColRequestId(int id);
    dynamic findByWaitingForApproval();
    dynamic findByAlreadyAccepted();
    dynamic findByRefuse();
}
