using CursoIdiomas.Application.Views;
using CursoIdiomas.Application.Views.Simple;
using CursoIdiomas.Domain.Application.Interfaces;
using CursoIdiomas.Domain.Turma.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers
{
    [Route("v1/api/")]
    [ApiController]
    public class TurmaControllers : ControllerBase
    {
        private readonly ITurmaService _turmaServices;

        public TurmaControllers(ITurmaService turmaServices)
        {
            _turmaServices = turmaServices;
        }


        [HttpGet]
        [Route("professores/{idProfessor}/turmas")]
        [ProducesDefaultResponseType(typeof(IEnumerable<TurmaSimpleView>))]
        public async Task<ActionResult<IEnumerable<TurmaSimpleView>>> GetAllByProfessor(System.Guid idProfessor)
        {

            return await _turmaServices.GetAllByProfessor(idProfessor);
        }



        [HttpPost]
        [Route("professores/{idProfessor}/turmas")]
        [ProducesDefaultResponseType(typeof(TurmaView))]
        public async Task<ActionResult<TurmaView>> Post(System.Guid idProfessor, [FromBody] TurmaDto turmaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _turmaServices.Registrar(idProfessor, turmaDTO);

        }

        [HttpPut]
        [Route("professores/turmas/{idTurma}")]
        [ProducesDefaultResponseType(typeof(TurmaView))]
        public async Task<ActionResult<TurmaView>> Put(System.Guid idTurma, [FromBody] TurmaDto turmaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _turmaServices.Atualizar(idTurma, turmaDTO);

        }

        [HttpDelete]
        [Route("professores/turmas/{idTurma}")]
        [ProducesDefaultResponseType(typeof(bool))]
        public async Task<ActionResult<bool>> DeleteTurma(System.Guid idTurma)
        {

            return await _turmaServices.Remover(idTurma);
        }

    }
}
