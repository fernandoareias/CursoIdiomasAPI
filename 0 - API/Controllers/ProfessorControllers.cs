using CursoIdiomas.Application.Boletim.Interfaces;
using CursoIdiomas.Application.CursoContext.Professor.DTO;
using CursoIdiomas.Application.Professor.Services;
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
        [Route("professores")]
        public async Task<ActionResult> GetAll() {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _professorAppService.GetAll();

            if (result.Data == null) return NotFound();
            if (result.Success == false && result.Data != null) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("professores/{idProfessor}")]
        public async Task<ActionResult> GetById(Guid idProfessor) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _professorAppService.Obter(idProfessor);
            if (result.Data == null) return NotFound(result);
            if (result.Success == false && result.Data != null) return BadRequest(result);


            return Ok(result);
        }

        [HttpPost]
        [Route("professores")]
        public async Task<ActionResult> Post([FromBody] ProfessorDTO model) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _professorAppService.Registrar(model);

            if (result == null) return BadRequest();
            if (result.Data == null) return NotFound(result);
            if (result.Success == false && result.Data != null) return BadRequest(result);


            return Ok(result);
        }

        [HttpPut]
        [Route("professores/{idProfessor}")]
        public async Task<ActionResult> Put(Guid idProfessor, [FromBody] ProfessorDTO model) {
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
        public async Task<ActionResult> Delete(Guid idProfessor) {
            var result = await _professorAppService.Remover(idProfessor);
            if (result.Success == false) return BadRequest();

            return Ok(result);
        }
    }
}
