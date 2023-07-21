using Microsoft.AspNetCore.Mvc;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Controllers;
[Route("policy")]
public class PolicyController : Controller
{

    private IPolicy policyService;
    public PolicyController(IPolicy policy)
    {
        policyService = policy;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create")]
    public IActionResult create([FromBody] Policy policy)
    {
        try
        {
            return Ok(new { result = policyService.create(policy) });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("get")]
    public IActionResult get()
    {
        try
        {
            return Ok(policyService.get());
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
            return Ok(policyService.findById(id));
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
            return Ok(new { result = policyService.delete(id) });
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
    public IActionResult update([FromBody] Policy policy)
    {
        try
        {
            return Ok(new { result = policyService.update(policy) });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
}
