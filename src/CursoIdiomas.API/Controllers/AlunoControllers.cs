using CursoIdiomas.Application.Views;
using CursoIdiomas.Application.Views.Simple;
using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers
{
    [ApiController]
    [Route("v1/api/")]
    public class AlunoControllers : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoControllers(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }



        [HttpGet]
        [Route("turmas/alunos")]
        [ProducesDefaultResponseType(typeof(IEnumerable<AlunoSimpleView>))]
        public async Task<ActionResult<IEnumerable<AlunoSimpleView>>> GetAll()
        {

            return await _alunoService.GetAll();
        }


        [HttpGet]
        [Route("turmas/alunos/{idAluno}")]
        [ProducesDefaultResponseType(typeof(AlunoView))]
        public async Task<ActionResult<AlunoView>> GetById(System.Guid idAluno)
        {

            return await _alunoService.Obter(idAluno);
        }

        [HttpPost]
        [Route("turmas/{idTurmas}/alunos")]
        [ProducesDefaultResponseType(typeof(AlunoView))]
        public async Task<ActionResult<AlunoView>> Post(System.Guid idTurmas, [FromBody] AlunoDto model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _alunoService.Registrar(idTurmas, model);
        }


        [HttpPut]
        [Route("turmas/alunos/{idAluno}")]
        [ProducesDefaultResponseType(typeof(AlunoView))]
        public async Task<ActionResult<AlunoView>> Put(System.Guid idAluno, [FromBody] AlunoDto model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _alunoService.Atualizar(idAluno, model);
        }

        [HttpDelete]
        [Route("turmas/alunos/{idAluno}")]
        [ProducesDefaultResponseType(typeof(object))]
        public async Task<ActionResult<object>> Delete(System.Guid idAluno)
        {

            return await _alunoService.Remover(idAluno);

        }


    }
}
