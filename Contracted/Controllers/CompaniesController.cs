using System.Collections.Generic;
using System.Threading.Tasks;
using Contracted.Models;
using Contracted.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers

{
  [ApiController]
  [Route("api/[controller]")]
  public class CompaniesController : ControllerBase
  {
    private readonly CompaniesService _CompaniesService;
    public CompaniesController(CompaniesService CompaniesService)
    {
      _CompaniesService = CompaniesService;
    }
    [HttpGet]
    public ActionResult<List<Company>> GetAll()
    {
      try
      {
        return Ok(_CompaniesService.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{CompaniesId}")]
    public ActionResult<Company> GetById(int CompaniesId)
    {
      try
      {
        return Ok(_CompaniesService.GetById(CompaniesId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Company>> Post([FromBody] Company compnayData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // for node reference - req.body.creatorId = req.userInfo.id
        // FIXME NEVER TRUST THE CLIENT
        companyData.CreatorId = userInfo.Id;
        Companies createdCompanies = _companyService.Post(companyData);
        createdCompanies.Owner = userInfo;
        return createdCompanies;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{CompaniesId}")]
    public async Task<ActionResult<string>> RemoveCompanies(int CompaniesId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _CompaniesService.RemoveCompanies(CompaniesId, userInfo.Id);
        return Ok("Companies was delorted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}