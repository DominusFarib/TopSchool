using Microsoft.AspNetCore.Mvc;
using TopSchool.Domain.Models;
using TopSchool.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TopSchool.API.Controllers
{
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
        // GET: api/<ProfessorController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _Service.GetAllAsync());
            //return new string[] { "value1", "value2" };
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return (IActionResult)_Service.Get(id);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
