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
    [Route("v1/cursos/professores")]
    public class AlunosController : ControllerBase
    {


        [HttpGet]
        [AllowAnonymous]
        [Route("turmas/alunos/")] // HTTP GET => https://localhost:5001/v1/cursos/professores/turmas/alunos
        //Retorna todos os alunos de todas as turmas
        public async Task<ActionResult<List<Aluno>>> GetAllAlunos([FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna uma lista de alunos registrados
                var alunos = await context.Alunos.AsNoTracking()
                .Include(x => x.Turma)
                .ThenInclude(y => y.Professores)
                .ThenInclude(z => z.Cursos)
                .ToListAsync();

                if (alunos == null)
                    return NotFound(new { message = "Não há alunos registrados." });

                // HTTP STATUS CODE => 200 
                return Ok(alunos);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


        // Retorna uma lista de alunos de uma determinada turma
        [HttpGet]
        [AllowAnonymous]
        [Route("turmas/{idTurma}/alunos/")] // HTTP GET => https://localhost:5001/v1/cursos/professores/turmas/{idTurma}/alunos
        public async Task<ActionResult<List<Aluno>>> GetAlunosByIdTurma(int idTurma, [FromServices] DataContext context)
        {
            try
            {
                // Verficia se existe aluno registrado na turma informada
                var aluno = await context.Alunos.AsNoTracking().Where(y => y.TurmaId == idTurma).ToArrayAsync();
                if (aluno == null)
                    return NotFound(new { message = "Não há alunos registrados nessa turma." });
                // HTTP STATUS CODE => 200 
                return Ok(aluno);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }



        // Busca o aluno pelo ID 
        [HttpGet]
        [AllowAnonymous]
        [Route("turmas/alunos/{id:int}")] // HTTP GET => https://localhost:5001/v1/cursos/professores/turmas/alunos/{id}
        public async Task<ActionResult<Aluno>> GetAlunoById(int id, [FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna o primeiro aluno encontrado que possui o ID passado via URL
                var alunos = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (alunos == null)
                    return NotFound(new { message = "Não foi possível encontrar o aluno." });

                // HTTP STATUS CODE => 200 
                return Ok(alunos);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("turmas/{idTurmas:int}/alunos/")] // HTTP POST => https://localhost:5001/v1/cursos/professores/turmas/{idTurmas}/alunos
        public async Task<ActionResult<Aluno>> Post(int idTurmas, [FromServices] DataContext context, [FromBody] Aluno model)
        {
            // Aluno deve ser cadastrado com turma;
            var aluno = await context.Alunos.AsNoTracking().Where(y => y.TurmaId == idTurmas).ToListAsync();

            if (model.TurmaId != idTurmas)
                return BadRequest(new { message = "Não foi possível registrar o aluno, ID inválido" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Uma turma não pode ter mais de 5 alunos;
            if (aluno.ToArray().Length >= 5)
                return BadRequest(new { message = "Essa turma já está cheia, tente registrar o aluno em outra." });

            try
            {
                context.Alunos.Add(model);
                await context.SaveChangesAsync();


                return Ok(new { message = "Aluno registrado com sucesso." });
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }



        [HttpPut]
        [AllowAnonymous]
        [Route("turmas/alunos/{idAluno:int}")] // HTTP PUT => https://localhost:5001/v1/cursos/professores/turmas/alunos/{idAluno}
        public async Task<ActionResult<Aluno>> Put(int idAluno, [FromServices] DataContext context, [FromBody] Aluno model)
        {

            if (model.Id != idAluno)
                // HTTP STATUS CODE => 404 
                return BadRequest(new { message = "Não foi possível atualizar o aluno, ID inválido." });

            if (!ModelState.IsValid)
                // HTTP STATUS CODE => 400 
                return BadRequest(ModelState);
            try
            {
                // Verifica se houve mudança no stado e as aplicas caso seja necessario
                context.Entry<Aluno>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                // Salva no banco 
                await context.SaveChangesAsync();
                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Aluno atualizado com sucesso." });
            }
            // Capturar o erro de concorrencia de escrita no banco, pode ser tratado posteriormente.
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Esse aluno já foi atualizado." });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("turmas/alunos/{id:int}")] // HTTP DELETE => https://localhost:5001/v1/cursos/professores/turmas/alunos/{id}
        public async Task<ActionResult<Aluno>> Delete(int id, [FromServices] DataContext context)
        {
            var aluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (aluno == null)
                return NotFound(new { message = "Não foi possível encontrar o aluno." });
            try
            {
                context.Alunos.Remove(aluno);
                await context.SaveChangesAsync();

                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Aluno removido com sucesso." });
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }
    }
}