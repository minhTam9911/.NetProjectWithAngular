using Project_ASP.Net_And_Angular.Models;

namespace Project_ASP.Net_And_Angular.Services;

public interface IEmpRegister
{

    bool create(EmpRegister register);
    dynamic get();
    dynamic findById(int id);
    dynamic findByUserName(string userName);
    bool update(EmpRegister register);
    bool delete(int id);
    dynamic findByEmailNoTracking(string emailNoTracking);
    bool existEmail(string email);
    bool existUserName(string userName);
    dynamic login (string userName, string password);
}
