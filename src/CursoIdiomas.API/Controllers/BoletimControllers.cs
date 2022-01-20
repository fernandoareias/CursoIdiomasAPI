using CursoIdiomas.Domain.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers
{
    [Route("v1/api/")]
    [ApiController]
    public class BoletimControllers : ControllerBase
    {
        private readonly IBoletimService _boletimServices;

        public BoletimControllers(IBoletimService boletimAppServices)
        {
            _boletimServices = boletimAppServices;
        }


        [HttpGet]
        [Route("cursos/professor/turmas/alunos/boletins/{idBoletim}")]
        [ProducesDefaultResponseType(typeof(object))]
        public async Task<ActionResult<object>> Visualizar(long idBoletim)
        {

            return await _boletimServices.Obter(idBoletim);

        }
    }
}
