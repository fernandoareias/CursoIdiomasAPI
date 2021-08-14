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
    public class BoletimControllers : ControllerBase
    {

        [HttpGet]
        [Route("/v1/cursos/turmas/alunos/matriculas/boletins")]

        public async Task<ActionResult<List<Boletim>>> GetAll([FromServices] DataContext context)
        {
            try
            {
                var boletins = await context.Boletims.AsNoTracking().ToListAsync();
                if (boletins == null)
                    return NotFound(new { message = "Não há boletim registrado." });

                return Ok(boletins);
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }

        }

        [HttpGet]
        [Route("/v1/cursos/turmas/alunos/matriculas/{matriculaId}/boletins")]

        public async Task<ActionResult<List<Boletim>>> GetAllByMatricula(string matriculaId, [FromServices] DataContext context)
        {
            try
            {
                var boletins = await context.Boletims.AsNoTracking().Where(x => x.MatriculaId.ToString() == matriculaId).ToListAsync();
                if (boletins == null)
                    return NotFound(new { message = "Esta matricula não possui boletins registrados." });

                return Ok(boletins);
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }

        }


        [HttpPost]
        [Route("/v1/cursos/turmas/alunos/matriculas/{matriculaId}/boletins")]

        public async Task<ActionResult<List<Boletim>>> Post(string matriculaId, [FromServices] DataContext context, [FromBody] Boletim model)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var matriculas = await context.Matriculas.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == matriculaId);
                if (matriculas == null)
                    return NotFound(new { message = "Não é possível encontrar a matricula informada" });



                context.Boletims.Add(new Boletim(model, matriculaId));
                await context.SaveChangesAsync();

                return Ok(new { message = "Boletim registrado com sucesso." });
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpPut]
        [Route("/v1/cursos/turmas/alunos/matriculas/boletins/{boletimId}")]

        public async Task<ActionResult<Boletim>> Put(string boletimId, [FromServices] DataContext context, [FromBody] Boletim model)
        {
            try
            {
                var boletim = await context.Boletims.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == boletimId);
                if (boletim == null)
                    return NotFound(new { message = "Não foi posssível encontrar o boletim informado." });

                model.setId(boletim.Id);
                model.setMatriculaId(boletim.MatriculaId);
                model.setDate(boletim.DataPub);
                model.setAtualizacao();

                context.Entry<Boletim>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (System.Exception)
            {

                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

        [HttpDelete]
        [Route("/v1/cursos/turmas/alunos/matriculas/boletins/{boletimId}")]

        public async Task<ActionResult<Boletim>> Delete(string boletimId, [FromServices] DataContext context)
        {
            try
            {
                var boletim = await context.Boletims.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == boletimId);
                if (boletim == null)
                    return NotFound();

                context.Boletims.Remove(boletim);
                await context.SaveChangesAsync();
                return Ok(new { message = "Boletim removido com sucesso." });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro. Por favor, tente novamente mais tarde." });
            }
        }

    }
}