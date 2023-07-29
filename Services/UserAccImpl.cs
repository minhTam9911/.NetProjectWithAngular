using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Services;

public class UserAccImpl : IUserAcc
{
    private DatabaseContext db;
    public UserAccImpl(DatabaseContext db) { this.db = db; }

    public bool create(Account acc)
    {
        try
        {
            db.Accounts.Add(acc);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public Account findByCode(string code)
    {
        try
        {
            return db.Accounts.Where(a => a.UserName == code).SingleOrDefault();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null;
        }
    }

    public List<Account> get()
    {
        try
        {
            return db.Accounts.ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null ;
        }
    }

    public bool update(Account acc)
    {
        try
        {
            db.Entry(acc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        };
    }
}
