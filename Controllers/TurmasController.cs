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
    public class TurmasControllers : ControllerBase
    {


        [HttpGet]
        [Route("cursos/professores/turmas")]

        public async Task<ActionResult<Turma>> GetAll([FromServices] DataContext context)
        {
            try
            {
                var turmas = await context.Turmas.AsNoTracking().Include(y => y.Cursos).Include(x => x.Professores).ToListAsync();
                if (turmas == null)
                    return NotFound();

                return Ok(turmas);
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


        [HttpGet]
        [Route("cursos/professores/{professorId}/turmas")]

        public async Task<ActionResult<List<Turma>>> GetTurmaByTeacher(string professorId, [FromServices] DataContext context)
        {
            try
            {
                var turmas = await context.Turmas.AsNoTracking()
                .Include(x => x.Cursos).Where(y => y.ProfessoresId.ToString() == professorId).ToListAsync();

                if (turmas == null)
                    return NotFound();

                return Ok(turmas);
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }





        [HttpPost]
        [Route("cursos/professores/turmas")]
        public async Task<ActionResult<Turma>> Post([FromServices] DataContext context, [FromBody] Turma model)
        {

            try
            {
                context.Turmas.Add(model);
                await context.SaveChangesAsync();
                return Ok($"TurmaID = {model.Id.ToString()}");
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


        [HttpPost]
        [Route("cursos/{CursoId}/professores/{ProfessorId}/turmas")]

        public async Task<ActionResult<Turma>> PostBy(string CursoId, string ProfessorId, [FromServices] DataContext context, [FromBody] Turma model)
        {
            try
            {
                var cursos = await context.Cursos.AsNoTracking()
            .FirstOrDefaultAsync(y => y.Id.ToString() == CursoId);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (cursos == null)
                    return NotFound();

                var professor = await context.Professores.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.ToString() == ProfessorId);

                if (professor == null)
                    return NotFound();

                model.setCursoId(CursoId);
                model.setProfessorId(ProfessorId);

                context.Turmas.Add(model);
                await context.SaveChangesAsync();
                return Ok(new { turmaId = model.Id });
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }

        }


        [HttpDelete]
        [Route("cursos/professores/turmas/{turmaId}")]

        // Verifica se a turma existe e depois verifica se a mesma possui alguma matricula ativa
        public async Task<ActionResult<Turma>> Delete(string turmaId, [FromServices] DataContext context)
        {
            try
            {
                var turma = await context.Turmas.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.ToString() == turmaId);

                if (turma == null)
                    return NotFound(new { message = "Não foi possível encontrar a turma informada." });

                var matriculas = await context.Matriculas.AsNoTracking()
                .Where(x => x.TurmaId.ToString() == turmaId).ToListAsync();

                foreach (var item in matriculas)
                    if (item.Ativa == true)
                        return BadRequest(new { message = "Não é possível deletar a turma, pois há alunos ativos." });


                context.Turmas.Remove(turma);
                await context.SaveChangesAsync();
                return Ok(new { message = "Turma removida com sucesso." });
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


    }


}