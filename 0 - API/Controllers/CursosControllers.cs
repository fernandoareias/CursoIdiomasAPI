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
    }
}
