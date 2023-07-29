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

    public bool create(PolicyRequestDetail policyRequestDetail)
    {
        try
        {
            db.PolicyRequestDetails.Add(policyRequestDetail);
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
            db.PolicyRequestDetails.Remove(db.PolicyRequestDetails.Find(id));
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
