using CursoIdiomas.Application.Boletim.Interfaces;
using CursoIdiomas.Application.CursoContext.Boletim;
using CursoIdiomas.Application.CursoContext.Boletim.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers {
    [Route("v1/api/")]
    [ApiController]
    public class BoletimControllers : ControllerBase {
        private readonly IBoletimAppServices _boletimAppServices;

        public BoletimControllers(IBoletimAppServices boletimAppServices) {
            _boletimAppServices = boletimAppServices;
        }

        [HttpGet]
        [Route("cursos/professor/turmas/alunos/boletins")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<List<BoletimView>>))]
        public async Task<IActionResult> Listar() {
            var result = await _boletimAppServices.GetAll();

            if (result.Data == null) return NotFound(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("cursos/professor/turmas/alunos/boletins/{idBoletim}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<BoletimView>))]
        public async Task<IActionResult> Visualizar(long idBoletim) {
            var result = await _boletimAppServices.Obter(idBoletim);

            if (result.Data == null) return NotFound(result);

            return Ok(result);
        }


        [HttpPost]
        [Route("cursos/professor/turmas/alunos/{idAlunos}/boletins")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<BoletimView>))]
        public async Task<IActionResult> CadastrarBoletim(long idAlunos, [FromBody]BoletimDTO model) {

            var result = await _boletimAppServices.Registrar(idAlunos, model);
            if (result.Data == null) return NotFound(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("cursos/professor/turmas/alunos/boletins/{idBoletim}")]
        [ProducesDefaultResponseType(typeof(GenericCommandsResults<BoletimView>))]
        public async Task<IActionResult> DeletarBoletim(long idBoletim) {
            var result = await _boletimAppServices.Remover(idBoletim);

            if (result.Data == null) return NotFound(result);

            return Ok(result);
        }
    }
}
