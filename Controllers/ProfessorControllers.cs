using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CursoIdiomasAPI.Data;
using CursoIdiomasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoIdiomasAPI.Controllers
{
    [Route("v1/professores/")]
    public class ProfessorController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("")] // HTTP GET => https://localhost:5001/v1/professores/

        public async Task<ActionResult<List<Professores>>> Get([FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna uma lista de professores registrados
                var professores = await context.Professores.AsNoTracking().ToListAsync();
                if (professores == null)
                    // HTTP STATUS CODE => 404 
                    return NotFound();
                // HTTP STATUS CODE => 200 
                return Ok(professores);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return BadRequest();
            }
        }

        // Busca o professores pelo ID 
        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")] // HTTP GET => https://localhost:5001/v1/professores/{id}
        public async Task<ActionResult<List<Professores>>> GetById(int id, [FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna o primeiro professor encontrado que possui o ID passado via URL
                var professores = await context.Professores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (professores == null)
                    return NotFound(new { message = "Não foi possivel encontrar o professor" });

                // HTTP STATUS CODE => 200 
                return Ok(professores);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return BadRequest(new { message = "" });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")] // HTTP POST => https://localhost:5001/v1/professores/
        public async Task<ActionResult<Professores>> Post([FromServices] DataContext context, [FromBody] Professores model)
        {
            if (!ModelState.IsValid)
                // HTTP STATUS CODE => 400 
                return BadRequest(ModelState);

            context.Professores.Add(model);
            await context.SaveChangesAsync();

            // HTTP STATUS CODE => 200 
            return Ok(model);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("{id:int}")] // HTTP PUT => https://localhost:5001/v1/professores/{id}
        public async Task<ActionResult<Professores>> Put(int id, [FromServices] DataContext context, [FromBody] Professores model)
        {
            if (model.Id != id)
                // HTTP STATUS CODE => 404 
                return NotFound();

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
                return Ok(model);
            }
            // Capturar o erro de concorrencia de escrita no banco, pode ser tratado posteriormente.
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Esse curso ja foi atualizada" });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{id:int}")] // HTTP DELETE => https://localhost:5001/v1/cursos/{id}

        public async Task<ActionResult<Professores>> Delete(int id, [FromServices] DataContext context)
        {
            // Caso exista, retorna o primeiro curso encontrado que possui o ID passado via URL
            var professores = await context.Professores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (professores == null)

                // HTTP STATUS CODE => 404
                return NotFound(new { message = "Não foi possivel encontrar o cursos" });
            try
            {
                context.Professores.Remove(professores);
                await context.SaveChangesAsync();

                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Curso removido com sucesso !" });
            }
            catch (System.Exception)
            {

                // HTTP STATUS CODE => 400 
                return BadRequest(new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde" });
            }
        }

    }
}