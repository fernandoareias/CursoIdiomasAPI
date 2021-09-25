using CursoIdiomas.Application.Cursos.DTO;
using CursoIdiomas.Application.Cursos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers
{
    [Route("v1/api/")]
    [ApiController]
    public class CursosControllers : ControllerBase
    {
        private readonly ICursoAppServices _cursoAppService;

        public CursosControllers(ICursoAppServices cursoAppService)
        {
            _cursoAppService = cursoAppService;
        }


        [HttpGet]
        [Route("cursos")]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _cursoAppService.GetAll();
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpGet]
        [Route("cursos/{idCurso}")]
        public async Task<ActionResult> GetById(Guid idCurso) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _cursoAppService.ObterCurso(idCurso);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("cursos")]
        public async Task<ActionResult> Post([FromBody]CursoDTO model) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _cursoAppService.RegistrarCurso(model);

            if(result == null) 
                return BadRequest();

            return Ok(result);
        }


        [HttpPut]
        [Route("cursos/{idCurso}")]
        public async Task<ActionResult> Put(Guid idCurso, [FromBody] CursoDTO model) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _cursoAppService.AtualizarCurso(idCurso, model);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        [Route("curso/{idCurso}")]
        public async Task<ActionResult> Delete(Guid idCurso) {

            var result = await _cursoAppService.Remover(idCurso);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }



    }
}
