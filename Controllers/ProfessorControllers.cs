using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CursoIdiomasAPI.Data;
using CursoIdiomasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
// Completo
namespace CursoIdiomasAPI.Controllers
{
    [Route("v1/cursos/")]
    public class ProfessorController : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        [Route("professores")] // HTTP GET => https://localhost:5001/v1/cursos/professores

        public async Task<ActionResult<List<Professores>>> GetAllByAll([FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna uma lista de professores registrados
                var professores = await context.Professores.Include(x => x.Cursos).AsNoTracking().ToListAsync();
                if (professores == null)
                    // HTTP STATUS CODE => 404 
                    return NotFound(new { message = "Não há professores registrados." });
                // HTTP STATUS CODE => 200 
                return Ok(professores);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{idCurso:int}/professores")] // HTTP GET => https://localhost:5001/v1/cursos/{idCurso}/professores
        public async Task<ActionResult<List<Professores>>> GetAllByIdCourse(int idCurso, [FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna o primeiro professor encontrado que possui o ID passado via URL
                var professores = await context.Professores.AsNoTracking().Where(x => x.CursoId == idCurso).ToListAsync();

                if (professores == null)
                    return NotFound(new { message = "Não há professor registrado neste curso." });

                // HTTP STATUS CODE => 200 
                return Ok(professores);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        // Busca o professores pelo ID 
        [HttpGet]
        [AllowAnonymous]
        [Route("professores/{id:int}")] // HTTP GET => https://localhost:5001/v1/cursos/professores/{id}
        public async Task<ActionResult<Professores>> GetByTeacherId(int id, [FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna o primeiro professor encontrado que possui o ID passado via URL
                var professores = await context.Professores
                .AsNoTracking()
                .Include(x => x.Cursos)
                .FirstOrDefaultAsync(x => x.Id == id);

                if (professores == null)
                    return NotFound(new { message = "Não foi possível encontrar o professor." });

                // HTTP STATUS CODE => 200 
                return Ok(professores);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("{idCurso:int}/professores")] // HTTP POST => https://localhost:5001/v1/cursos/{idCurso}/professores
        public async Task<ActionResult<Professores>> Post(int idCurso, [FromServices] DataContext context, [FromBody] Professores model)
        {

            var curso = await context.Cursos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == idCurso);
            if (curso == null)
                return NotFound(new { message = "Não foi possivel encontrar o curso." });

            if (model.CursoId != idCurso)
                return BadRequest(new { message = "Não foi possível registrar o professor, ID inválido." });

            if (!ModelState.IsValid)
                // HTTP STATUS CODE => 400 
                return BadRequest(ModelState);

            try
            {
                context.Professores.Add(model);
                await context.SaveChangesAsync();

                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Professor registrado com sucesso." });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("professores/{id:int}")] // HTTP PUT => https://localhost:5001/v1/cursos/professores/{id}
        public async Task<ActionResult<Professores>> Put(int id, [FromServices] DataContext context, [FromBody] Professores model)
        {
            if (model.Id != id)
                // HTTP STATUS CODE => 404 
                return BadRequest(new { message = "Não foi possível registrar o professor ID inválido." });

            if (!ModelState.IsValid)
                // HTTP STATUS CODE => 400 
                return BadRequest(ModelState);

            try
            {
                // Verifica se houve mudança no stado e as aplicas caso seja necessario
                context.Entry<Professores>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                // Salva no banco 
                await context.SaveChangesAsync();
                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Professor atualizado com sucesso." });
            }
            // Capturar o erro de concorrencia de escrita no banco, pode ser tratado posteriormente.
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Esse professor já foi atualizado." });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("professores/{id:int}")] // HTTP DELETE => https://localhost:5001​/v1​/cursos​/professores​/{id}

        public async Task<ActionResult<Professores>> Delete(int id, [FromServices] DataContext context)
        {
            // Caso exista, retorna o primeiro curso encontrado que possui o ID passado via URL
            var professores = await context.Professores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (professores == null)

                // HTTP STATUS CODE => 404
                return NotFound(new { message = "Não foi possível encontrar o professor." });
            try
            {
                context.Professores.Remove(professores);
                await context.SaveChangesAsync();

                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Professor removido com sucesso." });
            }
            catch (System.Exception)
            {

                // HTTP STATUS CODE => 400 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

    }
}