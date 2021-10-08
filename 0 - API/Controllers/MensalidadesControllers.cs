using CursoIdiomas.Application.Boletim.Interfaces;
using CursoIdiomas.Application.CursoContext.Mensalidades.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.API.Controllers {

    [Route("v1/api/")]
    [ApiController]
    public class MensalidadesControllers : ControllerBase {

        private readonly IMensalidadesAppServices _mensalidadeAppService;

        public MensalidadesControllers(
            IMensalidadesAppServices mensalidadeAppService
        ) {
            _mensalidadeAppService = mensalidadeAppService;
        }

        [HttpGet]
        [Route("cursos/professor/turmas/alunos/mensalidades")]
        public async Task<IActionResult> ListarMensalides() {

            var result = await _mensalidadeAppService.GetAll();

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("cursos/professor/turmas/alunos/mensalidades/{idMensalidade}")]
        public async Task<IActionResult> VisualizarMensalidade(long idMensalidade) {
            
            var result = await _mensalidadeAppService.Obter(idMensalidade);
            
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("cursos/professor/turmas/alunos/{idAluno}/mensalidades")]
        public async Task<IActionResult> RegistrarMensalidade(long idAluno, [FromBody]MensalidadeDTO model) {

            var result = await _mensalidadeAppService.Registrar(idAluno, model);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("cursos/professor/turmas/alunos/mensalidades/{idMensalidade}")]
        public async Task<IActionResult> DeleteMensalidade(long idMensalidade) {
            
            var result = await _mensalidadeAppService.Remover(idMensalidade);
            if (result == null) return NotFound();

            return Ok(result);
        }

    }
}
