

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CursoIdiomasAPI.Data;
using CursoIdiomasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoIdiomasAPI.Controllers
{
    [Route("v1")]
    public class Matriculas : ControllerBase
    {
        [HttpGet]
        [Route("cursos/turmas/alunos/matriculas")]

        public async Task<ActionResult<List<Aluno>>> GetAllAlunos([FromServices] DataContext context)
        {
            var alunos = await context.Matriculas.Include(x => x.Turmas).ThenInclude(x => x.Professores)
            .Include(x => x.Turmas).ThenInclude(y => y.Cursos).AsNoTracking().ToListAsync();
            if (alunos == null)
                return NotFound();
            return Ok(alunos);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("cursos/turmas/alunos/matriculas/{matriculaId}")]

        public async Task<ActionResult<Matricula>> Put(string matriculaId, [FromServices] DataContext context, [FromBody] Matricula model)
        {
            try
            {
                var matricula = await context.Matriculas.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == matriculaId);

                if (matricula == null)
                    return NotFound();

                context.Entry<Matricula>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(new { message = "Matricula atualizada com sucesso." });
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Essa matricula ja foi atualizada" });
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpDelete]
        [Route("cursos/matriculas/{matriculaId}")]

        public async Task<ActionResult<Matricula>> Delete(string matriculaId, [FromServices] DataContext context)
        {
            var matricula = await context.Matriculas.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == matriculaId);
            if (matricula == null)
                return NotFound();

            if (!matricula.Ativa)
                return BadRequest(new { message = "Não foi possivel deletar, pois a matricula ainda está ativa" });

            context.Matriculas.Remove(matricula);
            await context.SaveChangesAsync();

            return Ok(new { message = "Matricula removida com sucesso." });
        }

    }
}

/*


        [HttpGet]
        [AllowAnonymous]
        [Route("cursos/matriculas")]
        public async Task<ActionResult<List<Matricula>>> Get([FromServices] DataContext context)
        {
            try
            {
                // Lista todas as matriculas, com alunos, turmas, cursos e professores
                var matriculas = await context
                .Matriculas
                .AsNoTracking()
                .Include(x => x.Turmas)
                .ThenInclude(x => x.Cursos)
                .Include(x => x.Turmas)
                .ThenInclude(y => y.Professores)
                .ToListAsync();


                if (matriculas == null)
                    return NotFound(new { message = "Não foi possível encontrar a matricula" });

                return Ok(matriculas);
            }
            catch (System.Exception)
            {

                throw;
            }
        }





*/