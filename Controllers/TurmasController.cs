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
            var turmas = await context.Turmas.AsNoTracking().Include(y => y.Cursos).Include(x => x.Professores).ToListAsync();
            if (turmas == null)
                return NotFound();

            return Ok(turmas);
        }





        [HttpPost]
        [Route("cursos/professores/turmas")]
        public async Task<ActionResult<Turma>> Post([FromServices] DataContext context, [FromBody] Turma model)
        {
            context.Turmas.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }


        [HttpPost]
        [Route("cursos/{CursoURL}/professores/{ProfessorURL}/turmas")]

        public async Task<ActionResult<Turma>> PostBy(string CursoURL, string ProfessorURL, [FromServices] DataContext context, [FromBody] Turma model)
        {
            var cursos = await context.Cursos.AsNoTracking().FirstOrDefaultAsync(y => y.URL == CursoURL);
            if (cursos == null)
                return NotFound();

            var professor = await context.Professores.AsNoTracking().FirstOrDefaultAsync(x => x.URL == ProfessorURL);
            if (professor == null)
                return NotFound();

            model.setCursoId(CursoURL);
            model.setProfessorId(ProfessorURL);

            context.Turmas.Add(model);
            await context.SaveChangesAsync();
            return Ok(new { message = "Turma criada com sucesso" });

        }

    }


}