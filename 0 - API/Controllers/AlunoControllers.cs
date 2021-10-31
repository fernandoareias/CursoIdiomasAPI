using CursoIdiomas.Application.Aluno.Interfaces;
using CursoIdiomas.Application.CursoContext.Aluno.DTOs;
using CursoIdiomas.Application.CursoContext.Aluno.View;
using CursoIdiomas.Application.Cursos.DTO;
using CursoIdiomas.Application.Cursos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers {
    [Route("v1/api/")]
    [ApiController]
    public class AlunoControllers : ControllerBase {
        private readonly IAlunoAppServices _alunoAppService;

        public AlunoControllers(IAlunoAppServices alunoAppService) {
            _alunoAppService = alunoAppService;
        }



        [HttpGet]
        [Route("cursos/professor/turmas/alunos")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<List<AlunoView>>))]
        public async Task<ActionResult> GetAll() {
            var result = await _alunoAppService.GetAll();
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpGet]
        [Route("cursos/professor/turmas/alunos/{idAluno}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<AlunoView>))]
        public async Task<ActionResult> GetById(long idAluno) {
            var result = await _alunoAppService.Obter(idAluno);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("cursos/professor/turmas/{idTurmas}/alunos")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<AlunoView>))]
        public async Task<ActionResult> Post(long idTurmas, [FromBody] AlunoCreateDTO model) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _alunoAppService.Registrar(idTurmas, model);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }


        [HttpPut]
        [Route("cursos/professor/turmas/alunos/{idAluno}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<AlunoView>))]
        public async Task<ActionResult> Put(long idAluno, [FromBody] AlunoCreateDTO model) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _alunoAppService.Atualizar(idAluno, model);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        [Route("cursos/professor/turmas/alunos/{idAluno}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<bool>))]
        public async Task<ActionResult> Delete(long idAluno) {
            var result = await _alunoAppService.Remover(idAluno);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }


    }
}
