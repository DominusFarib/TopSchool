using Microsoft.AspNetCore.Mvc;
using TopSchool.Domain.Models;
using TopSchool.Domain.Interfaces.Services;
using TopSchool.Domain.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopSchool.API.Controllers;

[ApiController]
[ApiVersion("6.0")]
[Route("topschool/v{version:apiVersion}/[controller]")]
public class ProfessorController : ControllerBase
{
    private readonly IProfessorService _Service;

    public ProfessorController(IProfessorService service)
    {
        _Service = service;
    }
    /// <summary>
    /// Obtém todos os professores ativos
    /// URL: topschool/professor/
    /// </summary>
    /// <returns></returns>
    // GET: api/<ProfessorController>
    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] PaginationConfig pageParams)
    {
        var result = await _Service.GetAllAsync(pageParams);

        Response.AddPagination(result.CurPage, result.TotalPages, result.ItemsPerPage, result.TotalItems);

        return Ok(result);
    }

    // GET api/<ProfessorController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _Service.Get(id));
    }

    // GET api/<ProfessorController>/5
    [HttpGet("getByAlunoId/{id}")]
    public async Task<IActionResult> GetByAlunoId(int id)
    {
        return Ok(await _Service.GetByAlunoIdAsync(id));
    }


    // POST api/<ProfessorController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProfessorModel oModel)
    {
        return Ok(await _Service.Post(oModel));
    }

    [HttpPost("addRange/")]
    public async Task<IActionResult> Post([FromBody] List<ProfessorModel> oModel)
    {
        var ret = await _Service.Post(oModel);
        return Ok(ret);
    }

    // PUT api/<ProfessorController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProfessorModel oModel)
    {
        if (_Service.Get(id) == null)
        {
            return BadRequest("Professor não encontrado");
        }

        return Ok(_Service.Put(oModel));
    }

    // DELETE api/<ProfessorController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_Service.Get(id) == null)
        {
            return BadRequest("Professor não encontrado");
        }

        return Ok(_Service.Delete(id));
    }

}
