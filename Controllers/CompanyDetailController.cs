using Microsoft.AspNetCore.Mvc;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Controllers;
[Route("company-detail")]
public class CompanyDetailController : Controller
{
    private ICompanyDetail companyService;
    public CompanyDetailController(ICompanyDetail companyDetailService)
    {
        companyService = companyDetailService;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create")]   
    public IActionResult create([FromBody] CompanyDetail companyDetail)
    {
        try
        {
            return Ok(companyService.create(companyDetail));
        }
        catch(Exception ex)
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
            return Ok(companyService.get());
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
            return Ok(companyService.findById(id));
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
            return Ok(companyService.delete(id));
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
    public IActionResult update([FromBody] CompanyDetail company)
    {
        try
        {
            return Ok(companyService.update(company));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
}
