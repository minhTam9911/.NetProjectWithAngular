using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Services;

public class PolicyImpl : IPolicy
{
    private DatabaseContext db;
    public PolicyImpl(DatabaseContext db) { this.db = db; }
    public bool create(Policy policy)
    {
        try
        {
            db.Policies.Add(policy);
            return db.SaveChanges()>0;
        }catch(Exception ex) {
            Debug.WriteLine(ex);
            return false; 
        }
    }

    public bool delete(int id)
    {

        try
        {
            db.Policies.Remove(db.Policies.Find(id));
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
            return db.Policies.Where(p=>p.Policyid == id).Select(p => new
            {
                policyId = p.Policyid,
                policyName = p.Policyname,
                policyDesc = p.Policydesc,
                amount = p.Amount,
                emi = p.Emi,
                companyId = p.Companyid,
                companyName = p.Company.CompanyName,
                medicalid = p.Medicalid
            }).FirstOrDefault();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return false;
        }
    }

    public dynamic get()
    {
        try
        {
            return db.Policies.Select(p=> new
            {
                policyId = p.Policyid,
                policyName= p.Policyname,
                policyDesc = p.Policydesc,
                amount = p.Amount,
                emi = p.Emi,
                companyId = p.Companyid,
                companyName = p.Company.CompanyName,
                medicalid = p.Medicalid
            }).ToList();
        }catch(Exception e)
        {
            Debug.WriteLine(e);
            return false;
        }
    }

    public bool update(Policy policy)
    {

        try
        {
            db.Entry(policy).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
