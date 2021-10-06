using CursoIdiomas.Application.CursoContext.Turma.DTOs;
using CursoIdiomas.Application.Turma.Interfaces;
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
        [Route("cursos/professores/{idProfessor}/turmas")]
        public async Task<ActionResult> GetAll() {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _turmaAppServices.GetAll();

            if (result.Data == null) return NotFound();
            if (result.Success == false && result.Data != null) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        [Route("cursos/professores/{idProfessor}/turmas")]
        public async Task<ActionResult> Post(long idProfessor, [FromBody] TurmaDTO turmaDTO) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _turmaAppServices.Registrar(idProfessor, turmaDTO);

            if (result.Data == null) return NotFound();
            if (result.Success == false && result.Data != null) return BadRequest(result);

            return Ok(result);
        }
    }
}
