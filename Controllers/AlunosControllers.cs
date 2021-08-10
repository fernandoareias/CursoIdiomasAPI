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
    [Route("v1/turmas")]
    public class AlunosController : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        [Route("alunos/")] // HTTP GET => https://localhost:5001/v1/turmas/alunos/
        public async Task<ActionResult<List<Aluno>>> GetAlunos([FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna uma lista de alunos registrados
                var alunos = await context.Alunos.Include(x => x.Turma).AsNoTracking().ToListAsync();



                if (alunos == null)
                    return NotFound(new { message = "Não ha alunos registrados" });

                // HTTP STATUS CODE => 200 
                return Ok(alunos);
            }
            catch (System.Exception)
            {

                // HTTP STATUS CODE => 400 
                return BadRequest(new { message = "" });
            }
        }

        // Buscar alunos pertence  a turma passada pela URL
        [HttpGet]
        [AllowAnonymous]
        [Route("{idTurma}/alunos/")] // HTTP GET => https://localhost:5001/v1/turmas/{id}/alunos/
        public async Task<ActionResult<List<Aluno>>> GetAlunosByIdTurma(int idTurma, [FromServices] DataContext context)
        {

            try
            {
                // Caso exista, retorna uma lista de alunos registrados
                var alunos = await context.Alunos.Include(x => x.Turma).AsNoTracking().Where(y => y.IdTurma == idTurma).ToListAsync();

                if (alunos == null)
                    return NotFound(new { message = "Não ha alunos registrados" });

                // HTTP STATUS CODE => 200 
                return Ok(alunos);
            }
            catch (System.Exception)
            {

                // HTTP STATUS CODE => 400 
                return BadRequest(new { message = "" });
            }
        }

        // Busca o aluno pertence a turma, passado pela url os 2 valores
        [HttpGet]
        [AllowAnonymous]
        [Route("{idTurma}/alunos/{idAluno}")] // HTTP GET => https://localhost:5001/v1/turmas/alunos/
        public async Task<ActionResult<List<Aluno>>> GetAlunosByIdTurmaAndIdAluno(int idTurma, int idAluno, [FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna uma lista de alunos registrados
                var alunos = await context
                .Alunos
                .Include(
                    x => x.Turma
                    ).Include(x => x.Turma.Professor).Include(x => x.Turma.Curso)
                    .AsNoTracking()
                    .Where(
                        y => y.IdTurma == idTurma
                        )
                        .Where(
                            z => z.Id == idAluno
                            ).ToListAsync();



                if (alunos == null)
                    return NotFound(new { message = "Não ha alunos registrados" });

                // HTTP STATUS CODE => 200 
                return Ok(alunos);
            }
            catch (System.Exception)
            {

                // HTTP STATUS CODE => 400 
                return BadRequest(new { message = "" });
            }
        }



        // Busca o aluno pelo ID 
        [HttpGet]
        [AllowAnonymous]
        [Route("alunos/{id:int}")] // HTTP GET => https://localhost:5001/v1/alunos/{id}
        public async Task<ActionResult<List<Aluno>>> GetById(int id, [FromServices] DataContext context)
        {
            try
            {
                // Caso exista, retorna o primeiro aluno encontrado que possui o ID passado via URL
                var alunos = await context.Alunos.Include(x => x.Turma).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (alunos == null)
                    return NotFound(new { message = "Não foi possivel encontrar o aluno" });

                // HTTP STATUS CODE => 200 
                return Ok(alunos);
            }
            catch (System.Exception)
            {
                // HTTP STATUS CODE => 400 
                return BadRequest(new { message = "" });
            }
        }

        // 


        // 
        [HttpPost]
        [AllowAnonymous]
        [Route("{idTurma:int}/alunos")] // HTTP POST => https://localhost:5001/v1/alunos/

        public async Task<ActionResult<Aluno>> Post(int idTurma, [FromServices] DataContext context, [FromBody] Aluno model)
        {
            if (!ModelState.IsValid)
                // HTTP STATUS CODE => 400 
                return BadRequest(ModelState);


            var alunos = await context.Alunos.Include(x => x.Turma).AsNoTracking().Where(y => y.IdTurma == idTurma).ToListAsync();

            if (alunos.ToArray().Length >= 5)
                return BadRequest(new { message = "Essa turma está cheie, tente registrar em outra" });
            try
            {

                context.Alunos.Add(model);
                await context.SaveChangesAsync();


                // HTTP STATUS CODE => 200 
                return Ok(model);
            }
            catch (System.Exception)
            {

                // HTTP STATUS CODE => 400 
                return BadRequest(new { message = "" });
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("{idTurmas:int}/alunos/{idAluno:int}")] // HTTP PUT => https://localhost:5001/v1/alunos/{id}
        public async Task<ActionResult<Aluno>> Put(int id, [FromServices] DataContext context, [FromBody] Aluno model)
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
                context.Entry<Aluno>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                // Salva no banco 
                await context.SaveChangesAsync();
                // HTTP STATUS CODE => 200 
                return Ok(model);
            }
            // Capturar o erro de concorrencia de escrita no banco, pode ser tratado posteriormente.
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Essa categoria ja foi atualizada" });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("alunos/{id:int}")] // HTTP DELETE => https://localhost:5001/v1/alunos/{id}

        public async Task<ActionResult<Aluno>> Delete(int id, [FromServices] DataContext context)
        {
            var aluno = await context.Alunos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (aluno == null)

                // HTTP STATUS CODE => 404
                return NotFound(new { message = "Não foi possivel encontrar o aluno" });
            try
            {
                context.Alunos.Remove(aluno);
                await context.SaveChangesAsync();

                // HTTP STATUS CODE => 200 
                return Ok(new { message = "Aluno removido com sucesso !" });
            }
            catch (System.Exception)
            {

                // HTTP STATUS CODE => 400 
                return BadRequest(new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde" });
            }
        }
    }
}