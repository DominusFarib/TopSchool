using Microsoft.AspNetCore.Mvc;
using TopSchool.Domain.Models;
using TopSchool.Domain.Interfaces.Services;

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
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _Service.GetAllAsync());
    }

    // GET api/<AlunoController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return (IActionResult)_Service.Get(id);
    }

    // POST api/<AlunoController>
    [HttpPost]
    public IActionResult Post([FromBody] AlunoModel oModel)
    {
        return Ok(_Service.Post(oModel));
    }

    // PUT api/<AlunoController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AlunoModel oModel)
    {
        if (_Service.Get(id) == null)
        {
            return BadRequest("Aluno não encontrado");
        }

        return Ok(_Service.Put(oModel));
    }

    // DELETE api/<AlunoController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
