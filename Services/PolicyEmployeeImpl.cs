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
            if(db.PoliciesonEmployees.Where(pe=>pe.Policyid == policyEmployee.Policyid && pe.Empno == policyEmployee.Empno).Count() > 0)
            {
                return false;
            }
            else
            {
                db.PoliciesonEmployees.Add(policyEmployee);
                return db.SaveChanges() > 0;
            }
           
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

    public bool existPE(int policyId, int empNo)
    {
        try
        {
            return db.PoliciesonEmployees.Where(pe=>pe.Empno== empNo && pe.Policyid ==policyId).Count() > 0;
        }catch(Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic findByColEmpno(int empno)
    {
        try
        {
            return db.PoliciesonEmployees.Where(pe => pe.Empno == empno).Select(pe => new
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
                companyName = pe.Companyname,
                startDate=pe.StartDate.Value.ToString("dd-MM-yyyy"),
                endDate=pe.EndDate.Value.ToString("dd-MM-yyyy")
            }).ToList();
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
                companyName = pe.Companyname,
                startDate = pe.StartDate.Value.ToString("dd-MM-yyyy"),
                endDate = pe.EndDate.Value.ToString("dd-MM-yyyy")
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
                companyName = pe.Companyname,
                startDate = pe.StartDate.Value.ToString("dd-MM-yyyy"),
                endDate = pe.EndDate.Value.ToString("dd-MM-yyyy")
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
