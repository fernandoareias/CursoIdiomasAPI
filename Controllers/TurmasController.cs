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
    [Route("v1/cursos/")]
    public class TurmaController : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        [Route("professores/turmas")] // HTTP GET => https://localhost:5001​/v1/cursos/professores/turmas
        public async Task<ActionResult<List<Turma>>> Get([FromServices] DataContext context)
        {
            var turmas = await context.Turmas.AsNoTracking().Include(y => y.Professores).ThenInclude(x => x.Cursos).ToListAsync();
            try
            {
                if (turmas == null)
                    return NotFound(new { message = "Não há turma registrada." });
                return Ok(turmas);
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        // Pega todas as turmas de um professor
        [HttpGet]
        [AllowAnonymous]
        [Route("professores/{idProfessor:int}/turmas/")] // HTTP GET => https://localhost:5001​​/v1​/cursos​/professores​/{idProfessor}​/turmas
        public async Task<ActionResult<List<Turma>>> GetAllClassByTeacher(int idProfessor, [FromServices] DataContext context)
        {
            try
            {
                var turmas = await context.Turmas.AsNoTracking()
                .Include(y => y.Professores)
                .ThenInclude(x => x.Cursos)
                .Where(y => y.ProfessoresId == idProfessor)
                .ToListAsync();

                if (turmas == null)
                    return NotFound(new { message = "Este professor não possui turma registrada." });
                return Ok(turmas);
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        // Pega todas as turmas de um professor
        [HttpGet]
        [AllowAnonymous]
        [Route("{idCurso:int}/professores/turmas/")] // HTTP GET => https://localhost:5001​​/v1/cursos/{idCurso}/professores/turmas
        public async Task<ActionResult<List<Turma>>> GetAllClassByCourse(int idCurso, [FromServices] DataContext context)
        {
            try
            {
                var turmas = await context.Turmas.AsNoTracking()
                .Include(y => y.Professores)
                .ThenInclude(x => x.Cursos)
                .ToListAsync();

                if (turmas == null)
                    return NotFound(new { message = "Este curso não possui turma registrada." });

                return Ok(turmas);
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("professores/turmas/{idTurma:int}")] // HTTP GET => https://localhost:5001​​/v1/cursos/professores/turmas/{idTurma}
        public async Task<ActionResult<List<Turma>>> GetAllClassById(int idTurma, [FromServices] DataContext context)
        {
            try
            {
                var turmas = await context.Turmas.AsNoTracking()
                .Include(y => y.Professores)
                .ThenInclude(x => x.Cursos)
                .FirstOrDefaultAsync(y => y.Id == idTurma);

                if (turmas == null)
                    return NotFound(new { message = "Não foi possível encontrar a turma" });
                return Ok(turmas);
            }
            catch (System.Exception)
            {
                throw;
            }
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("professores/{idProfessor}/turmas")] // HTTP POST => https://localhost:5001​​​/v1​/cursos​/professores​/{idProfessor}​/turmas

        public async Task<ActionResult<Turma>> Post(int idProfessor, [FromServices] DataContext context, [FromBody] Turma model)
        {
            // Verficia se as informações do modelo batem com a url
            if (model.ProfessoresId != idProfessor)
                return BadRequest(new { message = "Não foi possível registrar a turma, ID inválido" });

            // Procura pelo professor informado via URL e verifica sua existencia
            var professor = await context.Professores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == idProfessor);
            if (professor == null)
                return NotFound(new { message = "Não foi possível encontrar o professor." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Se tudo estiver OK, adiciona a nova turma e salva as mudanças
            try
            {
                context.Turmas.Add(model);
                await context.SaveChangesAsync();

                return Ok(new { message = "Turma registrada com sucesso." });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("professores/turmas/{idTurma:int}")] // HTTP PUT => https://localhost:5001​​/v1/cursos/professores/turmas/{idTurma}
        public async Task<ActionResult<Turma>> Put(int idTurma, [FromServices] DataContext context, [FromBody] Turma model)
        {
            if (model.Id != idTurma)
                // HTTP STATUS CODE => 404 
                return NotFound(new { message = "Não foi possível registrar o aluno, ID inválido." });

            if (!ModelState.IsValid)
                // HTTP STATUS CODE => 400 
                return BadRequest(ModelState);

            try
            {
                // Verifica se houve mudança no stado e as aplicas caso seja necessario
                context.Entry<Turma>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                // Salva no banco 
                await context.SaveChangesAsync();
                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Turma atualizada com sucesso." });
            }
            // Capturar o erro de concorrencia de escrita no banco, pode ser tratado posteriormente.
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Esta turma já foi atualizada" });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("professores/turmas/{idTurma:int}")] // HTTP DELETE => https://localhost:5001​​/v1/cursos/professores/turmas/{idTurma}

        public async Task<ActionResult<Turma>> Delete(int idTurma, [FromServices] DataContext context)
        {
            // Verifica se a turma informada existe
            var turma = await context.Turmas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == idTurma);
            if (turma == null)
                return NotFound(new { message = "Não foi possível encontrar esta turma" });
            // Turma não pode ser excluída se possuir alunos;
            // Caso a turma possua alunos, não sera possivel remove-la
            var aluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.TurmaId == idTurma);
            if (aluno != null)
                return BadRequest(new { message = "Não é possivel remover esta turma, pois existe alunos matriculados" });

            // Caso a turma exista e não possua alunos
            // Ela será removida e depois as mudanças serão são salvas.
            try
            {
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