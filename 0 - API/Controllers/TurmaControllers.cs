using CursoIdiomas.Application.CursoContext.Turma.DTOs;
using CursoIdiomas.Application.CursoContext.Turma.View;
using CursoIdiomas.Application.Turma.Interfaces;
using CursoIdiomas.Application.Turma.View.Simple;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers {
    [Route("v1/api/")]
    [ApiController]
    public class TurmaControllers : ControllerBase {
        private readonly ITurmaAppServices _turmaAppServices;

        public TurmaControllers(ITurmaAppServices turmaAppServices) {
            _turmaAppServices = turmaAppServices;
        }


        [HttpGet]
        [Route("cursos/professores/turmas")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<List<TurmaSimpleListViewModel>>))]
        public async Task<ActionResult> GetAll() {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _turmaAppServices.GetAll();

            if (result.Data == null) return NotFound();
            if (result.Success == false && result.Data != null) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("cursos/professores/{idProfessor}/turmas")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<TurmaView>))]
        public async Task<ActionResult> GetAllByProfessor(long idProfessor) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _turmaAppServices.GetAllByProfessor(idProfessor);

            if (result.Data == null) return NotFound();
            if (result.Success == false && result.Data != null) return BadRequest(result);

            return Ok(result);
        }



        [HttpPost]
        [Route("cursos/professores/{idProfessor}/turmas")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<TurmaView>))]
        public async Task<ActionResult> Post(long idProfessor, [FromBody] TurmaDTO turmaDTO) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _turmaAppServices.Registrar(idProfessor, turmaDTO);

            if (result.Data == null) return NotFound();
            if (result.Success == false && result.Data != null) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        [Route("cursos/professores/turmas/{idTurma}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<TurmaView>))]
        public async Task<ActionResult> Put(long idTurma, [FromBody]TurmaDTO turmaDTO) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _turmaAppServices.Atualizar(idTurma, turmaDTO);

            if (result.Data == null) return NotFound();
            if (result.Success == false && result.Data != null) return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("cursos/professores/turmas/{idTurma}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<bool>))]
        public async Task<ActionResult> DeleteTurma(long idTurma) {
           
            var result = await _turmaAppServices.Remover(idTurma);

            return Ok(result);
        }

    }
}
