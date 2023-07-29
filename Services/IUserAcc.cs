using Project_ASP.Net_And_Angular.Models;

namespace Project_ASP.Net_And_Angular.Services;

public interface IUserAcc
{
    List<Account> get();
    bool create(Account acc);
    Account findByCode(string code);
    bool update(Account acc);
}
