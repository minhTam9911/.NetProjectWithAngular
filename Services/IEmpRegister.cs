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
    bool sendSecurityCode(string email);
    bool verify(string code, string email);
    bool forgotPas(string email, string username);
    bool checkExistEmailAndUsername(string email, string username);
    bool changeForgotPass(int id, string newPass);
    public bool updateNoSavePass(int id, EmpRegister register);
}
