using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;

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



}
