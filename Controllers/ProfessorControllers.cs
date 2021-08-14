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
    public class Professor : ControllerBase
    {

        [HttpGet]
        [Route("cursos/professores")]

        public async Task<ActionResult<List<Professores>>> Get([FromServices] DataContext context)
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
        public async Task<ActionResult<Professores>> GetById(string professorId, [FromServices] DataContext context)
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
        public async Task<ActionResult<Professores>> Put(string professorId, [FromServices] DataContext context, [FromBody] Professores model)
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
                context.Entry<Professores>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        [HttpDelete]
        [AllowAnonymous]
        [Route("cursos/professores/{professorId}")] // HTTP DELETE => https://localhost:5001/v1/cursos/{id}

        public async Task<ActionResult<Professores>> Delete(string professorId, [FromServices] DataContext context)
        {

            // Verficia se o curso informado existe
            var professor = await context.Professores.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == professorId);
            if (professor == null)
                // HTTP STATUS CODE => 404
                return NotFound(new { message = "Não foi possível encontrar o curso." });

            // Verfica se o curso atual possui turmas ativas
            /*var turmas = await context.Cursos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (turmas != null)
                return BadRequest(new { message = "Não é possivel deletar cursos, pois ele possui turmas ativas" });
*/
            try
            {
                context.Professores.Remove(professor);
                await context.SaveChangesAsync();

                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Curso removido com sucesso." });
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }
    }
}