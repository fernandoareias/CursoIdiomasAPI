using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CursoIdiomasAPI.Data;
using CursoIdiomasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


// Possui os metódos responsaveis pelo CRUD
namespace CursoIdiomasAPI.Controllers
{
    // https://localhost:5001/v1/alunos/
    [Route("v1/")]
    public class AlunosController : ControllerBase
    {

        [HttpGet]
        [Route("cursos/turmas/alunos")]

        public async Task<ActionResult<List<Aluno>>> GetAllAlunos([FromServices] DataContext context)
        {
            var alunos = await context.Alunos.Include(x => x.Matricula)
            .ThenInclude(y => y.Turmas)
            .ThenInclude(x => x.Professores).Include(x => x.Matricula)
            .ThenInclude(y => y.Turmas).ThenInclude(z => z.Cursos).AsNoTracking().ToListAsync();
            if (alunos == null)
                return NotFound();
            return Ok(alunos);
        }

        [HttpGet]
        [Route("curso/turmas/{turmaId}/alunos")]

        public async Task<ActionResult<List<Aluno>>> GetAllByTurma(string turmaId, [FromServices] DataContext context)
        {
            var alunos = await context.Alunos.AsNoTracking().ToListAsync();
            if (alunos == null)
                return NotFound();


            return Ok(alunos);

        }
        [HttpGet]
        [Route("curso/turmas/alunos/{alunoId}")]

        public async Task<ActionResult<Aluno>> GetById(string alunoId, [FromServices] DataContext context)
        {
            try
            {
                var alunos = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(y => y.Id.ToString() == alunoId);

                if (alunos != null)
                    return Ok(alunos);
                return NotFound();
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("cursos/turmas/{turmaId}/alunos")]
        public async Task<ActionResult<Aluno>> Post(string turmaId, [FromServices] DataContext context, [FromBody] Aluno model)
        {
            var turma = await context.Turmas.AsNoTracking().FirstOrDefaultAsync(x => x.URL == turmaId);
            //System.Console.WriteLine($"Turma ID: {turma.URL}  |  Turma URL: {turmaId}");
            if (turma == null)
                return NotFound(new { message = "Não foi possivel encontrar a turma" });


            var matriculas = await context.Matriculas.AsNoTracking().Where(y => y.TurmaId.ToString("N") == turmaId.ToLower()).ToListAsync();
            if (matriculas.ToArray().Length >= 5)
                return BadRequest(new { message = "Esta turma já está cheia" });

            var searchAluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Email == model.Email);
            if (searchAluno != null)
                return BadRequest(new { message = "Este email já está registrado." });
            //if(matriculas.ToList()
            try
            {
                context.Alunos.Add(model);

                await context.SaveChangesAsync();
                context.Matriculas.Add(new Matricula(System.Guid.Parse(turmaId), model.Id));

                await context.SaveChangesAsync();
                return Ok(new { message = "Aluno registrado com sucesso" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        // Bug => DbUpdateConcurrencyException
        [HttpPut]
        [Route("curso/turmas/alunos/{alunoId}")]

        public async Task<ActionResult<Aluno>> Put(string alunoId, [FromServices] DataContext context, [FromBody] Aluno model)
        {
            try
            {
                var alunos = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(y => y.Id.ToString() == alunoId);
                if (alunos == null)
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                context.Entry<Aluno>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Ja foi atualizado parceiro" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [HttpDelete]
        [Route("curso/turmas/alunos/{alunoId}")]
        public async Task<ActionResult<Aluno>> Delete(string alunoId, [FromServices] DataContext context)
        {
            var aluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == alunoId);
            if (aluno == null)
                return NotFound();

            try
            {
                context.Alunos.Remove(aluno);
                await context.SaveChangesAsync();
                return Ok(new { message = "Aluno removido com sucesso" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

}