using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Project_ASP.Net_And_Angular.Controllers;
[Route("policy-employee")]
public class PolicyEmployeeController : Controller
{
    private IPolicyEmloyee policyEmloyeeService;
    public PolicyEmployeeController(IPolicyEmloyee policyEmloyeeService)
    {
        this.policyEmloyeeService = policyEmloyeeService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("get")]
    public IActionResult get()
    {
        try
        {
            return Ok(policyEmloyeeService.get());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create")]
    public IActionResult create([FromBody] PoliciesonEmployee policiesonEmployee)
    {
       // var data = JsonConvert.DeserializeObject<PoliciesonEmployee>(strPolicyEmp);
        try
        {
            return Ok(policyEmloyeeService.create(policiesonEmployee));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("multipart/form-data")]
    [HttpPost("create2")]
    public IActionResult create2(string strPoliciesonEmployee)
    {
         var data = JsonConvert.DeserializeObject<PoliciesonEmployee>(strPoliciesonEmployee, new IsoDateTimeConverter
         {
            DateTimeFormat = "dd-MM-yyyy"
         });
        try
        {
            return Ok(policyEmloyeeService.create(data));
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
    public IActionResult delete(long id)
    {
        try
        {
            return Ok(policyEmloyeeService.delete(id));
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
    public IActionResult update([FromBody] PoliciesonEmployee policiesonEmployee)
    {
        try
        {
            return Ok(policyEmloyeeService.update(policiesonEmployee));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("multipart/form-data")]
    [HttpPut("update2")]
    public IActionResult update2(string strpoliciesonEmployee)
    {
        
        var data = JsonConvert.DeserializeObject<PoliciesonEmployee>(strpoliciesonEmployee, new IsoDateTimeConverter
        {
            DateTimeFormat = "dd-MM-yyyy"
        });
        try
        {
            return Ok(policyEmloyeeService.update(data));
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
    public IActionResult Find(int id)
    {
        try
        {
            return Ok(policyEmloyeeService.findById(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("find-col-empno/{id}")]
    public IActionResult findColEmpNo(int id)
    {
        try
        {
            return Ok(policyEmloyeeService.findByColEmpno(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }



}
