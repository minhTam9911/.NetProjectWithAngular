using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project_ASP.Net_And_Angular.Services;

public class CompanyDetailImpl : ICompanyDetail
{
    private DatabaseContext db;
    public CompanyDetailImpl(DatabaseContext db) { this.db = db; }

    public bool create(CompanyDetail company)
    {
        try
        {
            db.CompanyDetails.Add(company);
            return db.SaveChanges()>0;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool delete(int id)
    {
        try
        {
            db.CompanyDetails.Remove(db.CompanyDetails.Find(id));
            return db.SaveChanges()>0;
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
            return db.CompanyDetails.Where(c=>c.CompanyId ==id).Select(c => new
            {
                companyId = c.CompanyId,
                companyName = c.CompanyName,
                address = c.Address,
                phone = c.Phone,
                companyUrl = c.CompanyUrl
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
            return db.CompanyDetails.Select(c => new
            {
                companyId=c.CompanyId, 
                companyName=c.CompanyName,
                address =c.Address,
                phone = c.Phone,
                companyUrl = c.CompanyUrl
            }).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool update(CompanyDetail company)
    {
        try
        {
            db.Entry(company).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges()>0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
