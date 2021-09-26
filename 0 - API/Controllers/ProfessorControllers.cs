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
        private readonly ProfessorAppServices _professorAppService;

        public ProfessorControllers(ProfessorAppServices professorAppService) {
            _professorAppService = professorAppService;
        }


        [HttpGet]
        [Route("professores")]
        public async Task<ActionResult> GetAll() {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _professorAppService.GetAll();
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("professores/{idProfessor}")]
        public async Task<ActionResult> GetById(Guid idProfessor) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _professorAppService.Obter(idProfessor);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("professores")]
        public async Task<ActionResult> Post([FromBody] ProfessorDTO model) {

        }
    }
}
