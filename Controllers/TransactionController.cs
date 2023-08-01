using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Project_ASP.Net_And_Angular.Models;
using Project_ASP.Net_And_Angular.Services;
using System.Diagnostics;

namespace Project_ASP.Net_And_Angular.Controllers;
[Route("transaction")]
public class TransactionController : Controller
{

    private ITransaction transactionService;
    public TransactionController(ITransaction transaction)
    {
        this.transactionService = transaction;
    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("get")]
    public IActionResult get()
    {
        try
        {
            return Ok(transactionService.get());
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
    public IActionResult create(string strTransaction)
    {
        var data = JsonConvert.DeserializeObject<TransactionDetail>(strTransaction, new IsoDateTimeConverter
        {
            DateTimeFormat = "dd-MM-yyyy"
        });
        try
        {
            return Ok(transactionService.create(data));
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
            return Ok(transactionService.delete(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }


    //[Produces("application/json")]
    //[Consumes("multipart/form-data")]
    //[HttpPut("update")]
    //public IActionResult update(string strPolicyRequest)
    //{

    //    var data = JsonConvert.DeserializeObject<PolicyRequestDetail>(strPolicyRequest, new IsoDateTimeConverter
    //    {
    //        DateTimeFormat = "dd-MM-yyyy"
    //    });
    //    try
    //    {
    //        return Ok(policyRequestService.update(data));
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex);
    //        return BadRequest(ex.Message);
    //    }
    //}


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("find/{id}")]
    public IActionResult Find(int id)
    {

        try
        {
            return Ok(transactionService.findById(id));
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
    public IActionResult findColEmpno(int id)
    {

        try
        {
            return Ok(transactionService.findByColEmpno(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("find-col-account/{id}")]
    public IActionResult findColAccount(int id)
    {

        try
        {
            return Ok(transactionService.findByColAccountant(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("money-all")]
    public IActionResult moneyAll()
    {

        try
        {
            return Ok(transactionService.moneyAll());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }


    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("money-col-empno/{id}")]
    public IActionResult moneyColEmpno(int id)
    {

        try
        {
            return Ok(transactionService.moneyFindByColEmpno(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
}
