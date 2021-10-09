using CursoIdiomas.Application.Boletim.Interfaces;
using CursoIdiomas.Application.CursoContext.Professor.DTO;
using CursoIdiomas.Application.CursoContext.Professor.View;
using CursoIdiomas.Application.Professor.Services;
using CursoIdiomas.Domain.Professor.View.Simple;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers {
    [Route("v1/api/")]
    [ApiController]
    public class ProfessorControllers : ControllerBase {
        private readonly IProfessorAppServices _professorAppService;

        public ProfessorControllers(IProfessorAppServices professorAppService) {
            _professorAppService = professorAppService;
        }


        [HttpGet]
        [Route("cursos/{idCurso}/professores")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<List<ProfessorSimpleListViewModel>>))]
        public async Task<ActionResult> GetAll(long idCurso) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _professorAppService.GetAll(idCurso);

            if (result.Data == null) return NotFound();
            if (result.Success == false && result.Data != null) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("professores/{idProfessor}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<List<ProfessorView>>))]
        public async Task<ActionResult> GetById(long idProfessor) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _professorAppService.Obter(idProfessor);
            if (result.Data == null) return NotFound(result);
            if (result.Success == false && result.Data != null) return BadRequest(result);


            return Ok(result);
        }

        [HttpPost]
        [Route("cursos/{idCurso}/professores")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<List<ProfessorView>>))]
        []
        public async Task<ActionResult> Post(long idCurso, [FromBody] ProfessorDTO model) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _professorAppService.Registrar(idCurso, model);

            if (result == null) return BadRequest();
            if (result.Data == null) return NotFound(result);



            return Ok(result);
        }

        [HttpPut]
        [Route("professores/{idProfessor}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<List<ProfessorView>>))]
        public async Task<ActionResult> Put(long idProfessor, [FromBody] ProfessorDTO model) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _professorAppService.Atualizar(idProfessor, model);

            if (result == null) return BadRequest();
            if (result.Data == null) return NotFound(result);
            if (result.Success == false && result.Data != null) return BadRequest(result);


            return Ok(result);
        }

        [HttpDelete]
        [Route("professores/{idProfessor}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<bool>))]
        public async Task<ActionResult> Delete(long idProfessor) {
            var result = await _professorAppService.Remover(idProfessor);
            if (result.Success == false) return BadRequest();

            return Ok(result);
        }
    }
}
