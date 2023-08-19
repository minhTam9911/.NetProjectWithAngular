using Project_ASP.Net_And_Angular.Models;

namespace Project_ASP.Net_And_Angular.Services;

public interface IPolicyEmloyee
{
    bool create(PoliciesonEmployee policyEmployee);
    dynamic get();
    dynamic findById(int id);
    bool update(PoliciesonEmployee policyEmployee);
    bool delete(long id);
    dynamic findByColEmpno(int empno);
    bool existPE(int policyId, int empNo);
}
