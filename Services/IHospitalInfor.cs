using Project_ASP.Net_And_Angular.Models;

namespace Project_ASP.Net_And_Angular.Services;

public interface IHospitalInfor
{
    bool create(HospitalInfo hospital);
    dynamic get();
    dynamic findById(int id);
    bool update(HospitalInfo hospital);
    bool delete(int id);
}
