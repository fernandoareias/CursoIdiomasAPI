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
    [Route("v1/")]
    public class MensalidadeControllers : ControllerBase
    {

        [HttpGet]
        [Route("cursos/turmas/alunos/matriculas/mensalidades")]
        public async Task<ActionResult<List<Mensalidade>>> Get([FromServices] DataContext context)
        {
            try
            {
                var mensalidades = await context.Mensalidades.AsNoTracking().ToListAsync();
                if (mensalidades == null)
                    return NotFound(new { message = "Não há mensalidades registradas." });

                return Ok(mensalidades);
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpGet]
        [Route("cursos/turmas/alunos/matriculas/{matriculaId}/mensalidades")]
        public async Task<ActionResult<List<Mensalidade>>> GetByMatricula(string matriculaId, [FromServices] DataContext context)
        {
            try
            {
                var matricula = await context.Matriculas.AsNoTracking().FirstOrDefaultAsync(y => y.Id.ToString() == matriculaId);
                if (matricula == null)
                    return NotFound(new { message = "Não foi possível encontrar ha matricula informada." });

                var mensalidades = await context.Mensalidades.AsNoTracking().Where(x => x.MatriculaId.ToString() == matriculaId).ToListAsync();
                if (mensalidades == null)
                    return NotFound(new { message = "Não há mensalidades registradas." });

                return Ok(mensalidades);
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpPost]
        [Route("/cursos/turmas/alunos/matriculas/{matriculaId}/mensalidades")]

        public async Task<ActionResult<Mensalidade>> Post(string matriculaId, [FromServices] DataContext context, [FromBody] Mensalidade model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                model.SetMatriculaId(System.Guid.Parse(matriculaId));
                context.Mensalidades.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpPut]
        [Route("/cursos/turmas/alunos/matriculas/mensalidades/{mensalidadeId}")]

        public async Task<ActionResult<Mensalidade>> Delete(string mensalidadeId, [FromServices] DataContext context, [FromBody] Mensalidade model)
        {
            try
            {
                var mensalidade = await context.Mensalidades.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == mensalidadeId);
                if (mensalidade == null)
                    return NotFound();

                model.SetId(mensalidade.Id);
                model.SetMatriculaId(mensalidade.MatriculaId);
                context.Entry<Mensalidade>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(new { message = "Mensalidade atualizada com sucesso." });
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Essa mensalidade ja foi atualizada" });
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

    }
}

