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
        [Route("alunos")]
        public async Task<ActionResult> GetAll() {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _alunoAppService.GetAll();
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpGet]
        [Route("alunos/{idAluno}")]
        public async Task<ActionResult> GetById(Guid idAluno) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _alunoAppService.Obter(idAluno);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("alunos")]
        public async Task<ActionResult> Post([FromBody] CursoDTO model) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _alunoAppService.Registrar(model);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }


        [HttpPut]
        [Route("alunos/{idAluno}")]
        public async Task<ActionResult> Put(Guid idAluno, [FromBody] CursoDTO model) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _alunoAppService.Atualizar(idAluno, model);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        [Route("alunos/{idAluno}")]
        public async Task<ActionResult> Delete(Guid idAluno) {

            var result = await _alunoAppService.Remover(idAluno);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }


    }
}
