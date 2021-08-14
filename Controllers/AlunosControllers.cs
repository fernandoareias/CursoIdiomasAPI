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

        // Caso exista, retorna uma lista contendo todos os alunos
        [HttpGet]
        [Route("cursos/turmas/alunos")]

        public async Task<ActionResult<List<Aluno>>> GetAllAlunos([FromServices] DataContext context)
        {
            try
            {
                // Busca todos os alunos 
                var alunos = await context.Alunos.AsNoTracking().ToListAsync();
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
        [Route("cursos/turmas/alunos/{alunoId}")]

        public async Task<ActionResult<Aluno>> GetById(string alunoId, [FromServices] DataContext context)
        {
            try
            {
                // Retorna o primeiro aluno encontrado que possui o ID informado via url
                var alunos = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(y => y.Id.ToString("N") == System.Guid.Parse(alunoId).ToString("N"));


                if (alunos == null)
                    return NotFound();

                return Ok(alunos);
            }
            catch (System.InvalidOperationException)
            {
                return BadRequest(new { message = "Formato do {alunoId} inválido." });
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


        [HttpPost]
        [Route("cursos/turmas/{turmaId}/alunos")]
        public async Task<ActionResult<Aluno>> Post(string turmaId, [FromServices] DataContext context, [FromBody] Aluno model)
        {
            try
            {
                // Verifica se a turma informada existe
                var turma = await context.Turmas.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.ToString() == turmaId);
                if (turma == null)
                    return NotFound(new { message = "Não foi possivel encontrar a turma" });

                // Verifica a quantidade de alunos matriculados nessa turma
                var matriculas = await context.Matriculas.AsNoTracking()
                .Where(y => y.TurmaId.ToString() == turmaId).ToListAsync();
                if (matriculas.ToArray().Length >= 5)
                    return BadRequest(new { message = "Esta turma já está cheia" });

                // Verficia se o email ja foi registrado
                var searchAluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Email == model.Email);
                if (searchAluno != null)
                    return BadRequest(new { message = "Este email já está registrado." });

                // Registra o novo aluno
                context.Alunos.Add(model);
                await context.SaveChangesAsync();
                // Gera a nova matricula
                context.Matriculas.Add(new Matricula(System.Guid.Parse(turmaId), model.Id));
                await context.SaveChangesAsync();
                return Ok(new { message = "Aluno registrado com sucesso" });
            }
            catch (System.InvalidOperationException e)
            {
                return BadRequest(new { message = $"Formato do turmaId inválido. = {e}" });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpPut]
        [Route("curso/turmas/alunos/{alunoId}")]

        public async Task<ActionResult<Aluno>> Put(string alunoId, [FromServices] DataContext context, [FromBody] Aluno model)
        {
            try
            {
                var alunos = await context.Alunos.AsNoTracking()
                .FirstOrDefaultAsync(y => y.Id.ToString("N") == System.Guid.Parse(alunoId).ToString("N"));
                if (alunos == null)
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                System.Console.WriteLine($"ANTES UPDATE: {alunos.Id} | {alunos.Nome}| {alunos.Email}");
                model.SetId(System.Guid.Parse(alunoId));
                context.Entry<Aluno>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                System.Console.WriteLine($"PÒS UPDATE: {model.Id} | {model.Nome}| {model.Email}");
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Ja foi atualizado parceiro" });
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


        [HttpDelete]
        [Route("curso/turmas/alunos/{alunoId}")]
        public async Task<ActionResult<Aluno>> Delete(string alunoId, [FromServices] DataContext context)
        {
            var aluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == alunoId);
            if (aluno == null)
                return NotFound();

            var matricula = await context.Matriculas.AsNoTracking()
            .FirstOrDefaultAsync(x => x.AlunoId.ToString("N") == System.Guid.Parse(alunoId).ToString("N"));

            try
            {
                context.Alunos.Remove(aluno);
                context.Matriculas.Remove(matricula);
                await context.SaveChangesAsync();
                return Ok(new { message = "Aluno removido com sucesso" });
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }
    }

}