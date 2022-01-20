using CursoIdiomas.Application.Views;
using CursoIdiomas.Application.Views.Simple;
using CursoIdiomas.Domain.Application.Interfaces;
using CursoIdiomas.Domain.Cursos.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers
{
    [Route("v1/api/")]
    [ApiController]
    public class CursosControllers : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosControllers(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }


        [HttpGet]
        [Route("cursos")]
        [ProducesDefaultResponseType(typeof(IEnumerable<CursoSimpleView>))]
        public async Task<ActionResult<IEnumerable<CursoSimpleView>>> GetAll()
        {
            return await _cursoService.GetAll();
        }


        [HttpGet]
        [Route("cursos/{idCurso}")]
        [ProducesDefaultResponseType(typeof(CursoView))]
        public async Task<ActionResult<CursoView>> GetById(System.Guid idCurso)
        {

            return await _cursoService.Obter(idCurso);
        }

        [HttpPost]
        [Route("cursos")]
        [ProducesDefaultResponseType(typeof(CursoView))]
        public async Task<ActionResult<CursoView>> Post([FromBody] CursoDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _cursoService.Registrar(model);

        }


        [HttpPut]
        [Route("cursos/{idCurso}")]
        [ProducesDefaultResponseType(typeof(CursoView))]
        public async Task<ActionResult<CursoView>> Put(System.Guid idCurso, [FromBody] CursoDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _cursoService.Atualizar(idCurso, model);

        }

        [HttpDelete]
        [Route("curso/{idCurso}")]
        [ProducesDefaultResponseType(typeof(object))]
        public async Task<ActionResult<object>> Delete(System.Guid idCurso)
        {

            return await _cursoService.Remover(idCurso);

        }
    }
}
