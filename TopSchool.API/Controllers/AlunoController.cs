using Microsoft.AspNetCore.Mvc;
using TopSchool.Domain.Models;
using TopSchool.Domain.Interfaces.Services;
using TopSchool.Domain.Helpers;

namespace TopSchool.API.Controllers;
[ApiController]
[ApiVersion("6.0")]
[Route("topschool/v{version:apiVersion}/[controller]")]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _Service;

    public AlunoController(IAlunoService service)
    {
        _Service = service;
    }
    /// <summary>
    /// Obtem todos os alunos ativos
    /// URL: topschool/aluno/getall
    /// </summary>
    /// <returns></returns>
    // GET: api/<AlunoController>
    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] PaginationConfig pageParams)
    {
        var result = await _Service.GetAllAsync(pageParams);

        Response.AddPagination(result.CurPage, result.TotalPages, result.ItemsPerPage, result.TotalItems);

        return Ok(result);
    }

    // GET api/<AlunoController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _Service.Get(id));
    }

    // POST api/<AlunoController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AlunoModel oModel)
    {
        return Ok(await _Service.Post(oModel));
    }

    [HttpPost("addRange/")]
    public async Task<IActionResult> Post([FromBody] List<AlunoModel> oModel)
    {
        var ret = await _Service.Post(oModel);
        return Ok(ret);
    }

    // PUT api/<AlunoController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AlunoModel oModel)
    {
        if (await _Service.Get(id) == null)
        {
            return BadRequest("Aluno não encontrado");
        }
        var ret = await _Service.Put(oModel);

        return Ok(ret);
    }

    // DELETE api/<AlunoController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
