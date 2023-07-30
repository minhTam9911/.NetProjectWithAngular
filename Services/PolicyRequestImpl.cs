using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Services;

public class PolicyRequestImpl : IPolicyRequest
{
    private DatabaseContext db;
    public PolicyRequestImpl(DatabaseContext db)
    {
        this.db = db;
    }

    public  int create(PolicyRequestDetail policyRequestDetail)
    {
        try
        {
            if(db.PolicyRequestDetails.Where(pr=>pr.PolicyId ==policyRequestDetail.PolicyId && pr.Empno == policyRequestDetail.Empno).Count() > 0)
            {
                return 0;
            }
            else
            {
                db.PolicyRequestDetails.Add(policyRequestDetail);
                db.SaveChanges();
                return policyRequestDetail.RequestId;
            }
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return 0;
        }
    }

    public bool delete(int id)
    {
        try
        {
            db.PolicyRequestDetails.Remove(db.PolicyRequestDetails.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic findByColEmpNo(int id)
    {
        try
        {
            return db.PolicyRequestDetails.Where(pr => pr.Empno == id).Select(pr => new
            {
                requestId = pr.RequestId,
                requestDate = pr.RequestDate.Value.ToString("dd-MM-yyyy"),
                empNo = pr.Empno,
                policyId = pr.PolicyId,
                policyName = pr.Policyname,
                policyAmount = pr.PolicyAmount,
                emi = pr.Emi,
                companyId = pr.CompanyId,
                companyName = pr.CompanyName,
                status = pr.Status

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
            return db.PolicyRequestDetails.Where(pr=> pr.RequestId == id).Select(pr => new
            {
                requestId = pr.RequestId,
                requestDate = pr.RequestDate.Value.ToString("dd-MM-yyyy"),
                empNo = pr.Empno,
                policyId = pr.PolicyId,
                policyName = pr.Policyname,
                policyAmount = pr.PolicyAmount,
                emi = pr.Emi,
                companyId=pr.CompanyId,
                companyName = pr.CompanyName,
                status = pr.Status

            }).SingleOrDefault();
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
            return db.PolicyRequestDetails.Select(pr => new
            {
                requestId = pr.RequestId,
                requestDate = pr.RequestDate.Value.ToString("dd-MM-yyyy"),
                empNo = pr.Empno,
                policyId = pr.PolicyId,
                policyName = pr.Policyname,
                policyAmount = pr.PolicyAmount,
                emi = pr.Emi,
                companyId = pr.CompanyId,
                companyName = pr.CompanyName,
                status = pr.Status

            }).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool update(PolicyRequestDetail policyRequestDetail)
    {
        try
        {
            db.Entry(policyRequestDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
