using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Services;

public class HospitalImpl : IHospitalInfor
{
    private DatabaseContext db;
    public HospitalImpl(DatabaseContext db) { this.db = db; }

    public bool create(HospitalInfo hospital)
    {
        try
        {
            db.HospitalInfos.Add(hospital);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool delete(int id)
    {
        try
        {
            if(db.Policies.Where(p=>p.Medicalid == id).Count() > 0)
            {
                return false;
            }
            else
            {
                db.HospitalInfos.Remove(db.HospitalInfos.Find(id));
                return db.SaveChanges() > 0;
            }
           
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic findById(int id)
    {
        try
        {
            return db.HospitalInfos.Where(c => c.HospitalId == id).Select(c => new
            {
                hospitalId = c.HospitalId,
                hospitalName = c.HospitalName,
                phoneNo = c.PhoneNo,
                location = c.Location,
                url = c.Url
            }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic get()
    {
        try
        {
            return db.HospitalInfos.Select(c => new
            {
                hospitalId = c.HospitalId,
                hospitalName = c.HospitalName,
                phoneNo = c.PhoneNo,
                location = c.Location,
                url = c.Url
            }).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool update(HospitalInfo hospital)
    {
        try
        {
            db.Entry(hospital).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
