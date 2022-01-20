
using CursoIdiomas.Application.Views;
using CursoIdiomas.Domain.Application.Interfaces;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Domain.Professor.View.Simple;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers
{
    [Route("v1/api/")]
    [ApiController]
    public class ProfessorControllers : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorControllers(IProfessorService professorService)
        {
            _professorService = professorService;
        }


        [HttpGet]
        [Route("cursos/{idCurso}/professores")]
        [ProducesDefaultResponseType(typeof(IEnumerable<ProfessorSimpleListViewModel>))]
        public async Task<ActionResult<IEnumerable<ProfessorSimpleView>>> GetAll(System.Guid idCurso)
        {

            return await _professorService.GetAll(idCurso);
        }

        [HttpGet]
        [Route("professores/{idProfessor}")]
        [ProducesDefaultResponseType(typeof(ProfessorView))]
        public async Task<ActionResult<ProfessorView>> GetById(System.Guid idProfessor)
        {

            return await _professorService.Obter(idProfessor);

        }

        [HttpPost]
        [Route("cursos/{idCurso}/professores")]
        [ProducesDefaultResponseType(typeof(ProfessorView))]

        public async Task<ActionResult<ProfessorView>> Post(System.Guid idCurso, [FromBody] ProfessorDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _professorService.Registrar(idCurso, model);

        }

        [HttpPut]
        [Route("professores/{idProfessor}")]
        [ProducesDefaultResponseType(typeof(ProfessorView))]
        public async Task<ActionResult<ProfessorView>> Put(System.Guid idProfessor, [FromBody] ProfessorDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _professorService.Atualizar(idProfessor, model);

        }

        [HttpDelete]
        [Route("professores/{idProfessor}")]
        [ProducesDefaultResponseType(typeof(bool))]
        public async Task<ActionResult<bool>> Delete(System.Guid idProfessor)
        {

            return await _professorService.Remover(idProfessor);

        }
    }
}
