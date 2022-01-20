using CursoIdiomas.Application.Views;
using CursoIdiomas.Application.Views.Simple;
using CursoIdiomas.Domain.Application.Interfaces;
using CursoIdiomas.Domain.Builders;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Services
{
    public class CursoServices : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoServices(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<ActionResult<CursoView>> Atualizar(System.Guid idCurso, CursoDto model)
        {
            var curso = await _cursoRepository.GetById(idCurso);
            if (curso == null)
            {
                return new BadRequestObjectResult(new { message = "Não foi possível encontrar o curso informado" });
            }

            curso.DataInicio = model.DataInicio;
            curso.CargaHoraria = model.CargaHoraria;
            curso.Nome = model.Nome;
            curso.Dificuldade = (Domain.Cursos.Enum.EDificuldade)model.Dificuldade;
            curso.DataTermino = model.DataTermino;

            var response = await _cursoRepository.Update(curso);

            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new CursoView(curso));
        }

        public async Task<ActionResult<IEnumerable<CursoSimpleView>>> GetAll()
        {
            var cursos = await _cursoRepository.GetAll();

            if (cursos == null)
            {
                return new NotFoundResult();
            }

            var views = cursos.Select(c => new CursoSimpleView(c)).ToList();

            return new OkObjectResult(views);
        }

        public async Task<ActionResult<CursoView>> Obter(System.Guid id)
        {
            var curso = await _cursoRepository.GetById(id);

            if (curso == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar o curso informado." });
            }

            return new OkObjectResult(new CursoView(curso));
        }

        public async Task<ActionResult<CursoView>> Registrar(CursoDto model)
        {
            var curso = new CursoBuilder()
                .Nome(model.Nome)
                .CargaHoraria(model.CargaHoraria)
                .Dificuldade(model.Dificuldade)
                .DataInicio(model.DataInicio)
                .DataTermino(model.DataTermino)
                .Build();


            var response = await _cursoRepository.Create(curso);

            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new CursoView(curso));
        }

        public async Task<ActionResult<object>> Remover(System.Guid idCurso)
        {
            var curso = await _cursoRepository.GetById(idCurso);

            if (curso == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar o curso informado." });
            }

            var response = await _cursoRepository.Remove(curso);

            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new { message = "Curso removido com sucesso!" });
        }
    }
}
