

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

        public async Task<ActionResult<List<Aluno>>> GetAllAlunos([FromServices] DataContext context)
        {
            try
            {
                var alunos = await context.Matriculas.AsNoTracking().ToListAsync();
                if (alunos == null)
                    return NotFound();
                return Ok(alunos);
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

                if (model.AlunoId.ToString("N") == "00000000000000000000000000000000")
                    model.SetAlunoId(matricula.AlunoId);

                if (model.TurmaId.ToString("N") == "00000000000000000000000000000000")
                    model.SetTurmaId(matricula.TurmaId);

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

        [HttpDelete]
        [Route("cursos/matriculas/{matriculaId}")]

        public async Task<ActionResult<Matricula>> Delete(string matriculaId, [FromServices] DataContext context)
        {
            try
            {
                var matricula = await context.Matriculas.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == matriculaId);
                if (matricula == null)
                    return NotFound();

                if (matricula.Ativa == true)
                    return BadRequest(new { message = "Não foi possivel deletar, pois a matricula ainda está ativa" });

                var aluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(y => y.Id.ToString() == matricula.AlunoId.ToString());
                if (aluno != null)
                    context.Alunos.Remove(aluno);

                var boletim = await context.Boletims.AsNoTracking().Where(x => x.MatriculaId.ToString() == matriculaId).ToListAsync();
                if (boletim != null)
                    foreach (var item in boletim)
                        context.Boletims.Remove(item);

                context.Matriculas.Remove(matricula);

                await context.SaveChangesAsync();

                return Ok(new { message = "Matricula removida com sucesso." });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

    }
}
