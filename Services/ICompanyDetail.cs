using Project_ASP.Net_And_Angular.Models;

namespace Project_ASP.Net_And_Angular.Services;

public interface ICompanyDetail
{
    bool create(CompanyDetail company);
    dynamic get();
    dynamic findById(int id);
   bool update(CompanyDetail company);
    bool delete(int id);
}
