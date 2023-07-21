using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Services;

public class EmpRegisterImpl : IEmpRegister
{
    private DatabaseContext db;
    public EmpRegisterImpl(DatabaseContext db) { this.db = db; }
    public bool create(EmpRegister register)
    {
        try
        {
            db.EmpRegisters.Add(register);
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
            db.EmpRegisters.Remove(db.EmpRegisters.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool existEmail(string email)
    {
        try
        {
            return db.EmpRegisters.Where(e => e.Email == email).Count()>0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool existUserName(string userName)
    {
        try
        {
            return db.EmpRegisters.Where(e => e.Username == userName).Count() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic findByEmailNoTracking(string emailNoTracking)
    {
        try
        {
            return db.EmpRegisters.Where(e=>e.Email == emailNoTracking).Select(e => new
            {
                empNo = e.Empno,
                designation = e.Designation,
                joihDate = e.Joindate,
                salary = e.Salary,
                firstName = e.Firstname,
                lastName = e.Lastname,
                username = e.Username,
                password = e.Password,
                address = e.Address,
                contactNo = e.Contactno,
                state = e.State,
                country = e.Country,
                city = e.City,
                policyStatus = e.Policystatus,
                policyId = e.Policyid,
                roleName = e.Rolename,
                accountStatus = e.AccountStatus,
                securityCode = e.SecurityCode,
                email = e.Email
            }).AsNoTracking().FirstOrDefault();
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
            return db.EmpRegisters.Where(e => e.Empno == id).Select(e => new
            {
                empNo = e.Empno,
                designation = e.Designation,
                joihDate = e.Joindate,
                salary = e.Salary,
                firstName = e.Firstname,
                lastName = e.Lastname,
                username = e.Username,
                password = e.Password,
                address = e.Address,
                contactNo = e.Contactno,
                state = e.State,
                country = e.Country,
                city = e.City,
                policyStatus = e.Policystatus,
                policyId = e.Policyid,
                roleName = e.Rolename,
                accountStatus = e.AccountStatus,
                securityCode = e.SecurityCode,
                email = e.Email
            }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic findByUserName(string userName)
    {
        try
        {
            return db.EmpRegisters.Where(e => e.Username == userName).Select(e => new
            {
                empNo = e.Empno,
                designation = e.Designation,
                joihDate = e.Joindate,
                salary = e.Salary,
                firstName = e.Firstname,
                lastName = e.Lastname,
                username = e.Username,
                password = e.Password,
                address = e.Address,
                contactNo = e.Contactno,
                state = e.State,
                country = e.Country,
                city = e.City,
                policyStatus = e.Policystatus,
                policyId = e.Policyid,
                roleName = e.Rolename,
                accountStatus = e.AccountStatus,
                securityCode = e.SecurityCode,
                email = e.Email
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
            return db.EmpRegisters.Select(e => new
            {
                empNo = e.Empno,
                designation = e.Designation,
                joihDate = e.Joindate,
                salary = e.Salary,
                firstName = e.Firstname,
                lastName = e.Lastname,
                username = e.Username,
                password = e.Password,
                address = e.Address,
                contactNo = e.Contactno,
                state = e.State,
                country = e.Country,
                city = e.City,
                policyStatus = e.Policystatus,
                policyId = e.Policyid,
                roleName = e.Rolename,
                accountStatus = e.AccountStatus,
                securityCode = e.SecurityCode,
                email = e.Email
            }).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public dynamic login(string userName, string password)
    {
        try
        {
            var data = db.EmpRegisters.Where(e => e.Username == userName).FirstOrDefault();
            if(BCrypt.Net.BCrypt.Verify(data.Password,password))
            {
                return new
                {
                    username = data.Username,
                    role = data.Rolename
                };
            }
            else
            {
                return new
                {
                    result = "Password invalid"
                };
            }
        }catch(Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool update(EmpRegister register)
    {
        try
        {
            db.Entry(register).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
