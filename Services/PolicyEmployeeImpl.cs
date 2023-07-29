using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Services;

public class PolicyEmployeeImpl : IPolicyEmloyee
{
    private DatabaseContext db;
    public PolicyEmployeeImpl(DatabaseContext db)
    {
        this.db = db;
    }

    public bool create(PoliciesonEmployee policyEmployee)
    {
        try
        {
            db.PoliciesonEmployees.Add(policyEmployee);
            return db.SaveChanges() > 0;
        }catch(Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool delete(long id)
    {
        try
        {
            db.PoliciesonEmployees.Remove(db.PoliciesonEmployees.Find(id));
            return db.SaveChanges() > 0;
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
            return db.PoliciesonEmployees.Where(pe => pe.Id == id).Select(pe => new
            {
                id = pe.Id,
                empNo = pe.Empno,
                policyId = pe.Policyid,
                policyName = pe.Policyname,
                policyStatus = pe.Policystatus,
                policyAmount = pe.Policyamount,
                policyDuration = pe.Policyduration,
                emi = pe.Emi,
                companyId = pe.Companyid,
                companyName = pe.Companyname
            }).FirstOrDefault() ;
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
            return db.PoliciesonEmployees.Select(pe => new
            {
                id = pe.Id,
                empNo = pe.Empno,
                policyId = pe.Policyid,
                policyName = pe.Policyname,
                policyStatus = pe.Policystatus,
                policyAmount = pe.Policyamount,
                policyDuration = pe.Policyduration,
                emi = pe.Emi,
                companyId = pe.Companyid,
                companyName = pe.Companyname
            }).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool update(PoliciesonEmployee policyEmployee)
    {
        try
        {
            db.Entry(policyEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
