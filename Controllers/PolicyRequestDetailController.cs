using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Controllers;
[Route("policy-request")]
public class PolicyRequestDetailController : Controller
{
    private IPolicyRequest policyRequestService;
    public PolicyRequestDetailController(IPolicyRequest policyRequestDetails)
    {
        policyRequestService = policyRequestDetails;
    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("get")]
    public IActionResult get()
    {
        try
        {
            return Ok(policyRequestService.get());
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
    public IActionResult create(string strPolicyRequest)
    {
         var data = JsonConvert.DeserializeObject<PolicyRequestDetail>(strPolicyRequest, new IsoDateTimeConverter
         {
             DateTimeFormat = "dd-MM-yyyy"
         });
        try
        {
            return Ok(policyRequestService.create(data));
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
            return Ok(policyRequestService.delete(id));
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
    public IActionResult update(string strPolicyRequest)
    {

        var data = JsonConvert.DeserializeObject<PolicyRequestDetail>(strPolicyRequest, new IsoDateTimeConverter
        {
            DateTimeFormat = "dd-MM-yyyy"
        });
        try
        {
            return Ok(policyRequestService.update(data));
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
            return Ok(policyRequestService.findById(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
}
