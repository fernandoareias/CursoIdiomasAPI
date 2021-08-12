using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CursoIdiomasAPI.Data;
using CursoIdiomasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//Completo
namespace CursoIdiomasAPI.Controllers
{
    [Route("v1/cursos/")]
    public class CursoController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("")] // HTTP GET => https://localhost:5001/v1/cursos/

        public async Task<ActionResult<List<Curso>>> Get([FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna uma lista de cursos registrados
                var cursos = await context.Cursos.AsNoTracking().ToListAsync();
                if (cursos == null)
                    return NotFound(new { message = "Não há curso registrado" });
                // HTTP STATUS CODE => 200 
                return Ok(cursos);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 500 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        // Busca o curso pelo ID 
        [HttpGet]
        [AllowAnonymous]
        [Route("{cursoId}")] // HTTP GET => https://localhost:5001/v1/cursos/{id}
        public async Task<ActionResult<Curso>> GetById(string cursoId, [FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna o primeiro aluno encontrado que possui o ID passado via URL
                var curso = await context.Cursos.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == cursoId);

                if (curso == null)
                    return NotFound(new { message = "Não foi possível encontrar o curso" });

                // HTTP STATUS CODE => 200 
                return Ok(curso);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 500 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }
        /*
                [HttpPost]
                [AllowAnonymous]
                [Route("")] // HTTP POST => https://localhost:5001/v1/cursos/
                public async Task<ActionResult<Curso>> Post([FromServices] DataContext context, [FromBody] Curso model)
                {
                    try
                    {
                        if (!ModelState.IsValid)
                            // HTTP STATUS CODE => 400 
                            return BadRequest(ModelState);

                        context.Cursos.Add(model);
                        await context.SaveChangesAsync();

                        // HTTP STATUS CODE => 200 
                        return Ok(new { message = "Curso registrado com sucesso." });
                    }
                    catch (System.Exception)
                    {
                        // HTTP STATUS CODE => 500
                        return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
                    }
                }
        */
        [HttpPut]
        [AllowAnonymous]
        [Route("{cursoId}")] // HTTP PUT => https://localhost:5001/v1/cursos/{id}
        public async Task<ActionResult<Curso>> Put(string cursoId, [FromServices] DataContext context, [FromBody] Curso model)
        {
            if (model.Id.ToString() != cursoId)
                // HTTP STATUS CODE => 404 
                return NotFound(new { message = "Não foi possível encontrar o curso informado" });

            if (!ModelState.IsValid)
                // HTTP STATUS CODE => 400 
                return BadRequest(ModelState);

            try
            {
                // Verifica se houve mudança no stado e as aplicas caso seja necessario
                context.Entry<Curso>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        [Route("{cursoId}")] // HTTP DELETE => https://localhost:5001/v1/cursos/{id}

        public async Task<ActionResult<Curso>> Delete(string cursoId, [FromServices] DataContext context)
        {

            // Verficia se o curso informado existe
            var cursos = await context.Cursos.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == cursoId);
            if (cursos == null)
                // HTTP STATUS CODE => 404
                return NotFound(new { message = "Não foi possível encontrar o curso." });

            // Verfica se o curso atual possui turmas ativas
            /*var turmas = await context.Cursos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (turmas != null)
                return BadRequest(new { message = "Não é possivel deletar cursos, pois ele possui turmas ativas" });
*/
            try
            {
                context.Cursos.Remove(cursos);
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