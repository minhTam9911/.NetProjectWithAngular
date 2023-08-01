using Project_ASP.Net_And_Angular.Models;

namespace Project_ASP.Net_And_Angular.Services;

public interface ITransaction
{
    bool create(TransactionDetail transaction);
    dynamic get();
    dynamic findById(int id);
//    bool update(PoliciesonEmployee policyEmployee);
    bool delete(int id);
    dynamic findByColEmpno(int empno);
    dynamic findByColAccountant(int id);
    decimal moneyFindByColEmpno(int empno);
    decimal moneyAll();
}
