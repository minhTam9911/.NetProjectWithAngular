using Microsoft.AspNetCore.Mvc;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Controllers;
[Route("user")]
public class UserController : Controller
{
    private IUserAcc userAccService;
    private IConfiguration configuration;
    public UserController(IUserAcc userAccService, IConfiguration configuration)
    {
        this.userAccService = userAccService;
        this.configuration = configuration;
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("get")]
    public IActionResult get()
    {
        try
        {
            return Ok(userAccService.get());
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
    public IActionResult create([FromBody] Account acc)
    {
        try
        {
            return Ok(userAccService.create(acc));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("get/{code}")]
    public IActionResult getByCode(string code)
    {
        try
        {
            return Ok(userAccService.findByCode(code));
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
    public IActionResult update([FromBody] Account acc)
    {
        try
        {
            return Ok(userAccService.update(acc));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
}
