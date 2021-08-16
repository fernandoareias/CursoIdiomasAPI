

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CursoIdiomasAPI.Data;
using CursoIdiomasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CursoIdiomasAPI.Controllers
{
    [Route("v1")]
    public class Matriculas : ControllerBase
    {
        [HttpGet]
        [Route("cursos/turmas/alunos/matriculas")]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 10)]

        public async Task<ActionResult<List<Matricula>>> GetAllAlunos([FromServices] DataContext context)
        {
            try
            {
                var alunos = await context.Matriculas.AsNoTracking().Include(x => x.Alunos).Include(y => y.Turmas)
                .ThenInclude(z => z.Curso).Include(x => x.Turmas).ThenInclude(w => w.Professor).ToListAsync();
                if (alunos == null)
                    return NotFound();
                return Ok(alunos);
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpGet]
        [Route("cursos/turmas/alunos/{alunoId}/matriculas")]

        public async Task<ActionResult<Matricula>> GetMatriculaByAlunoId(string alunoId, [FromServices] DataContext context)
        {
            try
            {
                var matriculas = await context.Matriculas.AsNoTracking().Include(x => x.Alunos).Include(y => y.Turmas)
                .ThenInclude(z => z.Curso).Include(x => x.Turmas).ThenInclude(w => w.Professor).FirstOrDefaultAsync(x => x.AlunosId.ToString() == alunoId);
                if (matriculas == null)
                    return NotFound();

                return Ok(new { matriculas });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }




        [HttpPut]
        [AllowAnonymous]
        [Route("cursos/turmas/alunos/matriculas/{matriculaId}")]

        public async Task<ActionResult<Matricula>> Put(string matriculaId, [FromServices] DataContext context, [FromBody] Matricula model)
        {
            try
            {
                var matricula = await context.Matriculas.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.ToString() == matriculaId);

                if (model.AlunosId.ToString() == "00000000-0000-0000-0000-000000000000")
                    model.SetAlunoId(matricula.AlunosId);

                if (model.TurmasId.ToString() == "00000000-0000-0000-0000-000000000000")
                    model.SetTurmaId(matricula.TurmasId);

                if (matricula == null)
                    return NotFound();

                model.SetId(System.Guid.Parse(matriculaId));
                context.Entry<Matricula>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Essa matricula ja foi atualizada" });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }

        }


    }
}
