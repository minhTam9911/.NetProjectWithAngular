using Project_ASP.Net_And_Angular.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Project_ASP.Net_And_Angular.Controllers;

[Route("empRegister")]
public class EmpRegisterController : Controller
{
    private readonly SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("your-secret-key"));
    private IEmpRegister empRegisterService;
    private IConfiguration configuration;
    public EmpRegisterController(IEmpRegister empRegisterService, IConfiguration configuration)
    {
        this.empRegisterService = empRegisterService;
        this.configuration = configuration;
    }

    [Produces("application/json")]
    [Consumes("multipart/form-data")]
    [HttpPost("create")]
    public IActionResult create(string strRegister)
    {
        Debug.WriteLine("-----------" + strRegister);
        var register = JsonConvert.DeserializeObject<EmpRegister>(strRegister, new IsoDateTimeConverter
        {
            DateTimeFormat = "dd-MM-yyyy"
        });

        var password = BCrypt.Net.BCrypt.HashPassword(register.Password);
        string content = RandomHelper.RandomInt(6);
        Debug.WriteLine("--------------" + register);
        if (empRegisterService.existEmail(register.Email) || empRegisterService.existUserName(register.Username))
        {
            return Ok(new { result = "UserName or Email already" });
        }
        else
        {
            try
            {
                var mailHelper = new MailHelper(configuration);
                // var contentInput = "Your activation code is <h3>" + content + "</h3>";
                var statusSendEmail = mailHelper.Send(configuration["Gmail:UserName"], register.Email, "Security Alert", "Thank you for your successful registration. Please login to activate your account");
                // register.SecurityCode = content;
                register.Password = password.ToString();
                register.AccountStatus = false;

                if (statusSendEmail)
                {
                    return Ok(new { result = empRegisterService.create(register) });
                }
                else
                {
                    return Ok(new { result = "Send Email Invalid" });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }



    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("get")]
    public IActionResult get()
    {
        try
        {
            return Ok(empRegisterService.get());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("get-by-username/{username}")]
    public IActionResult getBuUsername(string username)
    {
        try
        {
            return Ok(empRegisterService.findByUserName(username));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("find/{id}")]
    public IActionResult find(int id)
    {
        try
        {
            return Ok(empRegisterService.findById(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpDelete("delete/{id}")]
    public IActionResult delete(int id)
    {
        try
        {
            return Ok(empRegisterService.delete(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("multipart/form-data")]
    [HttpPut("update")]
    public IActionResult update(string strRegister)
    {
        var input = JsonConvert.DeserializeObject<EmpRegister>(strRegister, new IsoDateTimeConverter
        {
            DateTimeFormat = "dd-MM-yyyy"
        });

        try
        {

            return Ok(new { result = empRegisterService.update(input) });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("profile/{id}")]
    public IActionResult Profile(int id)
    {
        try
        {
            return Ok(empRegisterService.findById(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("multipart/form-data")]
    [HttpPost("login")]
    public IActionResult login(string data)
    {
        //var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Substring("Bearer ".Length);
        var input = JsonConvert.DeserializeObject<Account>(data);
        Debug.WriteLine(BCrypt.Net.BCrypt.HashPassword(input.Password));
        if (empRegisterService.findByUserName(input.UserName) != null)
        {
            try
            {
                return Ok(empRegisterService.login(input.UserName, input.Password));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
        else
        {
            return BadRequest(new { result = "Username not already!" });
        }

    }

    [Produces("application/json")]
    [Consumes("multipart/form-data")]
    [HttpGet("send-code/{email}")]
    public IActionResult sendCode(string email)
    {

        //var input = JsonConvert.DeserializeObject<Account>(data);

        try
        {
            return Ok(empRegisterService.sendSecurityCode(email));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("verify/{email}/{code}")]
    public IActionResult verify(string email, string code)
    {
        try
        {
            return Ok(empRegisterService.verify(code, email));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }

    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("check-exist-email-username/{email}/{username}")]
    public IActionResult checkExistAccountForGot(string email, string username)
    {
        try
        {
            return Ok(empRegisterService.checkExistEmailAndUsername(email, username));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }

    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("send-code-forgot/{email}/{username}")]
    public IActionResult sendCodeForGot(string email, string username)
    {
        try
        {
            return Ok(empRegisterService.forgotPas(email, username));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }

    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("change-forgot-pass/{id}/{newpass}")]
    public IActionResult changeForGotPassword(int id, string newPass)
    {
        try
        {
            var hashPass = BCrypt.Net.BCrypt.HashPassword(newPass);
            return Ok(empRegisterService.changeForgotPass(id, hashPass));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }

    }

}
