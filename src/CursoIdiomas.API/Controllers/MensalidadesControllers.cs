using CursoIdiomas.Domain.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers
{

    [Route("v1/api/")]
    [ApiController]
    public class MensalidadesControllers : ControllerBase
    {

        private readonly IMensalidadesService _mensalidadeService;

        public MensalidadesControllers(
            IMensalidadesService mensalidadeService
        )
        {
            _mensalidadeService = mensalidadeService;
        }



        [HttpGet]
        [Route("cursos/professor/turmas/alunos/mensalidades/{idMensalidade}")]
        [ProducesDefaultResponseType(typeof(object))]
        public async Task<ActionResult<object>> VisualizarMensalidade(long idMensalidade)
        {

            return await _mensalidadeService.ObterFatura(idMensalidade);

        }

    }
}
