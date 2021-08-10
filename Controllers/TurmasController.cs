using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CursoIdiomasAPI.Data;
using CursoIdiomasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CursoIdiomasAPI.Controllers
{
    [Route("v1/turmas/")]
    public class TurmaController : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        [Route("")]

        public async Task<ActionResult<List<Turma>>> Get([FromServices] DataContext context)
        {
            try
            {
                var turmas = await context.Turmas.Include(x => x.Curso).Include(y => y.Professor).AsNoTracking().ToListAsync();
                if (turmas == null)
                    return NotFound();
                return Ok(turmas);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]

        public async Task<ActionResult<Turma>> GetById(int id, [FromServices] DataContext context)
        {
            try
            {
                var turmas = await context.Turmas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (turmas == null)
                    return NotFound();
                return Ok(turmas);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]

        public async Task<ActionResult<Turma>> Post([FromServices] DataContext context, [FromBody] Turma model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                context.Turmas.Add(model);
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [HttpDelete]
        [AllowAnonymous]
        [Route("{idTurma:int}")]

        public async Task<ActionResult<Turma>> Delete(int idTurma, [FromServices] DataContext context)
        {
            var aluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.IdTurma == idTurma);
            if (aluno != null)
                return BadRequest(new { message = "Não é possivel remover essa turma, pois existe alunos matriculados" });

            var turma = await context.Turmas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == idTurma);
            if (turma == null)
                return NotFound(new { message = "Não foi possivel encontrar essa turma" });

            try
            {
                context.Turmas.Remove(turma);
                await context.SaveChangesAsync();
                return Ok(new { message = "Turma removida com sucesso ! " });
            }
            catch (System.Exception)
            {

                return BadRequest(new { message = "Opsssssss " });
            }

        }



    }
}