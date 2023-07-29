using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Project_ASP.Net_And_Angular.Helper;
using Project_ASP.Net_And_Angular.Models;
using System.Diagnostics;
using System.Globalization;

namespace Project_ASP.Net_And_Angular.Services;

public class EmpRegisterImpl : IEmpRegister
{
    private DatabaseContext db;
    private IConfiguration configuration;
    public EmpRegisterImpl(DatabaseContext db, IConfiguration configuration)
    {
        this.db = db;
        this.configuration = configuration;
    }

   
    public bool checkExistEmailAndUsername(string email, string username)
    {
        try
        {
            var debug = db.EmpRegisters.Where(e => e.Username == username && e.Email == email).Count();
            Debug.WriteLine("------------" + debug);
            return db.EmpRegisters.Where(e => e.Username == username && e.Email == email).Count() > 0;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

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
            if(db.PoliciesonEmployees.Where(pe=>pe.Empno== id).Count() > 0 || 
                db.PolicyRequestDetails.Where(pe => pe.Empno == id).Count() > 0)
            {
                return false;
            }
            else
            {
                db.EmpRegisters.Remove(db.EmpRegisters.Find(id));
                return db.SaveChanges() > 0;
            }
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
            return db.EmpRegisters.Where(e => e.Email == email).Count() > 0;
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
            return db.EmpRegisters.Where(e => e.Email == emailNoTracking).Select(e => new
            {
                empNo = e.Empno,
                designation = e.Designation,
                joinDate = e.Joindate.Value.ToString("dd-MM-yyyy"),
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
                joinDate = e.Joindate.Value.ToString("dd-MM-yyyy"),
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
                joinDate = e.Joindate.Value.ToString("dd-MM-yyyy"),
                salary = e.Salary,
                firstName = e.Firstname,
                lastName = e.Lastname,
                username = e.Username,
 //               password = e.Password,
                address = e.Address,
                contactNo = e.Contactno,
                state = e.State,
                country = e.Country,
                city = e.City,
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

    public bool forgotPas(string email, string username)
    {
        try
        {
            var check = db.EmpRegisters.Where(e => e.Username == username && e.Email == email).Count() >0;
            if(check) {
                var data = db.EmpRegisters.Where(e => e.Username == username && e.Email == email).AsNoTracking().SingleOrDefault();
                string content = RandomHelper.RandomInt(6);
                var mailHelper = new MailHelper(configuration);
                var contentInput = "Your activation code is <h3>" + content + "</h3>";
                var statusSendEmail = mailHelper.Send(configuration["Gmail:UserName"], data.Email, "Security Alert", contentInput);
                data.SecurityCode = content;
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
           
        }catch(Exception ex) { 
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
                joinDate =e.Joindate.Value.ToString("dd-MM-yyyy"),
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
            var check = db.EmpRegisters.Where(e => e.Username == userName).SingleOrDefault();
            Debug.WriteLine(BCrypt.Net.BCrypt.Verify(password, check.Password));
            if (BCrypt.Net.BCrypt.Verify(password, check.Password))
            {
                return new
                {
                    id = check.Empno,
                    username = check.Username,
                    role = check.Designation,
                    status = check.AccountStatus
                };
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null;
        }
    }

    public bool sendSecurityCode(string email)
    {
        try
        {
            var data = db.EmpRegisters.Where(e => e.Email == email).AsNoTracking().SingleOrDefault();
            string content = RandomHelper.RandomInt(6);
            var mailHelper = new MailHelper(configuration);
            var contentInput = "Your activation code is <h3>" + content + "</h3>";
            var statusSendEmail = mailHelper.Send(configuration["Gmail:UserName"], data.Email, "Security Alert", contentInput);
            data.SecurityCode = content;
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
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

    public bool verify(string code, string email)
    {
        try
        {
            var data = db.EmpRegisters.Where(e => e.Email == email).AsNoTracking().SingleOrDefault();
            if (data.SecurityCode == code)
            {
                data.SecurityCode = null;
                data.AccountStatus = true;
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool changeForgotPass(int id, string newPass)
    {
        try
        {
            var data = db.EmpRegisters.Find(id);
            data.Password = newPass;
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool updateNoSavePass(int id, EmpRegister register)
    {
       
        try
        {
            var data = db.EmpRegisters.Find(id);
            string pass = data.Password.ToString();
            data = register;
            data.Password = pass;
            data.Empno= id;
            db.Entry(data).State= EntityState.Modified;
            return db.SaveChanges()>0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
