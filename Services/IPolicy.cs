using Project_ASP.Net_And_Angular.Models;

namespace Project_ASP.Net_And_Angular.Services;

public interface IPolicy
{

    bool create(Policy policy);
    dynamic get();
    dynamic findById(int id);
    bool update(Policy policy);
    bool delete(int id);
}

