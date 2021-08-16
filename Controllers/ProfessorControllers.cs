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
    [Route("v1/")]
    public class ProfessorControlleer : ControllerBase
    {

        [HttpGet]
        [Route("cursos/professores")]

        public async Task<ActionResult<List<Professor>>> Get([FromServices] DataContext context)
        {
            try
            {
                var professor = await context.Professores.AsNoTracking().ToListAsync();
                if (professor == null)
                    return NotFound(new { message = "Não há professor registrado" });
                return Ok(professor);
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("cursos/professores/{professorId}")] // HTTP GET => https://localhost:5001/v1/cursos/{id}
        public async Task<ActionResult<Professor>> GetById(string professorId, [FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna o primeiro aluno encontrado que possui o ID passado via URL
                var professor = await context.Professores.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == professorId);

                if (professor == null)
                    return NotFound(new { message = "Não foi possível encontrar o professor" });

                // HTTP STATUS CODE => 200 
                return Ok(professor);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 500 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


        [HttpPut]
        [AllowAnonymous]
        [Route("cursos/professores/{professorId}")] // HTTP PUT => https://localhost:5001/v1/cursos/{id}
        public async Task<ActionResult<Professor>> Put(string professorId, [FromServices] DataContext context, [FromBody] Professor model)
        {


            if (!ModelState.IsValid)
                // HTTP STATUS CODE => 400 
                return BadRequest(ModelState);

            try
            {
                var professor = await context.Professores.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == professorId);
                if (professor == null)
                    return NotFound();

                model.SetId(professor.Id);
                // Verifica se houve mudança no stado e as aplicas caso seja necessario
                context.Entry<Professor>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                // Salva no banco 
                await context.SaveChangesAsync();
                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Curso atualizado com sucesso." });
            }
            // Capturar o erro de concorrencia de escrita no banco, pode ser tratado posteriormente.
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Esse curso já foi atualizado." });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

    }
}