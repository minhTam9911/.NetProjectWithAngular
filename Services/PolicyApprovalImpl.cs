using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Services;

public class PolicyApprovalImpl : IPolicyApproval
{
    private DatabaseContext db;
    public PolicyApprovalImpl(DatabaseContext db) { this.db = db; }
    public bool create(PolicyApprovalDetail policyApproval)
    {
        try
        {
            db.PolicyApprovalDetails.Add(policyApproval);
            return db.SaveChanges()>0;
        }catch(Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool delete(int id)
    {
        try
        {
            db.PolicyApprovalDetails.Remove(db.PolicyApprovalDetails.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool deleteByColRequestId(int id)
    {
        try
        {
            db.PolicyApprovalDetails.Remove(db.PolicyApprovalDetails.Where(pa=>pa.RequestId==id).SingleOrDefault());
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic findByAlreadyAccepted()
    {
        try
        {
            return db.PolicyApprovalDetails.Where(pa => pa.Status == "Already Accepted").Select(pa => new
            {
                id = pa.Id,
                policyId = pa.PolicyId,
                requestId = pa.RequestId,
                date = pa.Date.Value.ToString("dd-MM-yyyy"),
                amount = pa.Amount,
                status = pa.Status,
                reason = pa.Reason,
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
            return db.PolicyApprovalDetails.Where(pa=>pa.Id==id).Select(pa => new
            {
                id = pa.Id,
                policyId = pa.PolicyId,
                requestId = pa.RequestId,
                date = pa.Date.Value.ToString("dd-MM-yyyy"),
                amount = pa.Amount,
                status = pa.Status,
                reason = pa.Reason,
            }).SingleOrDefault();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic findByRefuse()
    {
        try
        {
            return db.PolicyApprovalDetails.Where(pa => pa.Status == "Refuse").Select(pa => new
            {
                id = pa.Id,
                policyId = pa.PolicyId,
                requestId = pa.RequestId,
                date = pa.Date.Value.ToString("dd-MM-yyyy"),
                amount = pa.Amount,
                status = pa.Status,
                reason = pa.Reason,
            }).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic findByWaitingForApproval()
    {
        try
        {
            return db.PolicyApprovalDetails.Where(pa => pa.Status == "Waiting For Approval").Select(pa => new
            {
                id = pa.Id,
                policyId = pa.PolicyId,
                requestId = pa.RequestId,
                date = pa.Date.Value.ToString("dd-MM-yyyy"),
                amount = pa.Amount,
                status = pa.Status,
                reason = pa.Reason,
            }).ToList();
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
            return db.PolicyApprovalDetails.Select(pa => new
            {
                id=pa.Id,
                policyId = pa.PolicyId,
                requestId = pa.RequestId,
                date = pa.Date.Value.ToString("dd-MM-yyyy"),
                amount= pa.Amount,
                status = pa.Status,
                reason = pa.Reason,
            }).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool update(PolicyApprovalDetail policyApproval)
    {
        try
        {
            db.Entry(policyApproval).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
