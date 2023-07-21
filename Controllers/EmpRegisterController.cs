using Project_ASP.Net_And_Angular.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;
using System.Globalization;

namespace Project_ASP.Net_And_Angular.Controllers;
[Route("empRegister")]
public class EmpRegisterController : Controller
{
    private IEmpRegister empRegisterService;
    private IConfiguration configuration;
    public EmpRegisterController(IEmpRegister empRegisterService, IConfiguration configuration) { 
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
        String content = RandomHelper.RandomInt(6);
        Debug.WriteLine("--------------" + register);
       if(empRegisterService.existEmail(register.Email) || empRegisterService.existUserName(register.Username))
        {
            return Ok(new { result = "UserName or Email already" });
        }
        else
        {
            try
            {
                var mailHelper = new MailHelper(configuration);
                var contentInput = "Your activation code is <h3>" + content + "</h3>";
                var statusSendEmail = mailHelper.Send(configuration["Gmail:UserName"], register.Email, "Security Alert", contentInput);
                register.SecurityCode = content;
                register.Password = password;
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
            return Ok(new { result = empRegisterService.delete(id) });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update")]
    public IActionResult update([FromBody] EmpRegister register)
    {
        try
        {
            return Ok(new { result = empRegisterService.update(register) });
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
        var input = JsonConvert.DeserializeObject<Account>(data);
        if (empRegisterService.findByUserName(input.Username))
        {
            try
            {
                return Ok(empRegisterService.login(input.Username,input.Password)) ;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
        else
        {
            return BadRequest();
        }
        
    }
}
