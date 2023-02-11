using Microsoft.AspNetCore.Mvc;
using ProjectoSchool_API.Data;
using ProjectoSchool_API.Models;

namespace ProjectoSchool_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : Controller
    {
        public IRepository _repo { get; }

        [HttpGet(Name = "Professor")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProfessorAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha Banco de Dados");
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> GetId(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetProfessorAsyncById(ProfessorId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha Banco de Dados");
            }
        }

        [HttpPost(Name = "Professor")]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/professor/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha Banco de Dados");
            }
            return BadRequest();
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int ProfessorId, Professor model)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(ProfessorId, false);
                if (professor == null) return NotFound();

                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    professor = await _repo.GetProfessorAsyncById(ProfessorId, true);
                    return Created($"/api/professor/{model.Id}", professor);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha Banco de Dados");
            }

            return BadRequest();
        }

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> Delete(int ProfessorId)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(ProfessorId, false);
                if (professor == null) return NotFound();

                _repo.Delete(professor);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha Banco de Dados");
            }

            return BadRequest();
        }

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

    }
}
