using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Controllers;
[Route("policy-approval")]
public class PolicyApprovalController : Controller
{
    private IPolicyApproval policyApprovalService;
    public PolicyApprovalController(IPolicyApproval policyApprovalService)
    {
        this.policyApprovalService = policyApprovalService;
    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("get")]
    public IActionResult get()
    {
        try
        {
            return Ok(policyApprovalService.get());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("multipart/form-data")]
    [HttpPost("create")]
    public IActionResult create(string strPolicyApproval)
    {
        var data = JsonConvert.DeserializeObject<PolicyApprovalDetail>(strPolicyApproval, new IsoDateTimeConverter
        {
            DateTimeFormat = "dd-MM-yyyy"
        });
        try
        {
            return Ok(policyApprovalService.create(data));
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
            return Ok(policyApprovalService.delete(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpDelete("delete-col-request/{id}")]
    public IActionResult deleteByColRequestId(int id)
    {
        try
        {
            return Ok(policyApprovalService.deleteByColRequestId(id));
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
    public IActionResult update(string strPolicyApproval)
    {

        var data = JsonConvert.DeserializeObject<PolicyApprovalDetail>(strPolicyApproval, new IsoDateTimeConverter
        {
            DateTimeFormat = "dd-MM-yyyy"
        });
        try
        {
            return Ok(policyApprovalService.update(data));
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
            return Ok(policyApprovalService.findById(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("find-waiting-for-approval")]
    public IActionResult findByWaitingForApproval()
    {

        try
        {
            return Ok(policyApprovalService.findByWaitingForApproval());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("find-refuse")]
    public IActionResult findByRefuse()
    {

        try
        {
            return Ok(policyApprovalService.findByRefuse());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("find-already-accepted")]
    public IActionResult findByAlreadyAccepted()
    {

        try
        {
            return Ok(policyApprovalService.findByAlreadyAccepted());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

}
