using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project_ASP.Net_And_Angular.Services;

public class TransactionImpl : ITransaction
{
    private DatabaseContext db;
    public TransactionImpl(DatabaseContext db)
    {
        this.db = db;
    }
    public bool create(TransactionDetail transaction)
    {
        try
        {
            db.TransactionDetails.Add(transaction);
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
            db.TransactionDetails.Remove(db.TransactionDetails.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic findByColEmpno(int empno)
    {
        try
        {
            return db.TransactionDetails.Where(t=>t.EmpNo == empno).Select(t => new
            {
                TransactionID=t.TransactionId,
                TransactionDate = t.TransactionDate,
                Amount = t.Amount,
                empNo  = empno,
                policyEmployeeId= t.PolicyEmployeeId,
                accountantId = t.AccountantId
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
            return db.TransactionDetails.Where(t => t.TransactionId == id).Select(t => new
            {
                TransactionID = t.TransactionId,
                TransactionDate = t.TransactionDate,
                Amount = t.Amount,
                empNo = t.EmpNo,
                policyEmployeeId = t.PolicyEmployeeId,
                accountantId = t.AccountantId
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
            return db.TransactionDetails.Select(t => new
            {
                TransactionID = t.TransactionId,
                TransactionDate = t.TransactionDate,
                Amount = t.Amount,
                empNo = t.EmpNo,
                policyEmployeeId = t.PolicyEmployeeId,
                accountantId = t.AccountantId
            }).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
