using CursoIdiomas.Application.Views;
using CursoIdiomas.Domain.Application.Interfaces;
using CursoIdiomas.Domain.Builders;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Domain.Professor.View.Simple;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Services
{
    public class ProfessorService : IProfessorService
    {

        private readonly IProfessorRepository _professorRepository;
        private readonly ICursoRepository _cursoRepository;

        public ProfessorService(
            IProfessorRepository professorRepository,
            ICursoRepository cursoRepository
        )
        {
            _professorRepository = professorRepository;
            _cursoRepository = cursoRepository;
        }

        public async Task<ActionResult<ProfessorView>> Atualizar(System.Guid idProfessor, ProfessorDto model)
        {
            var professor = await _professorRepository.GetById(idProfessor);
            if (professor == null)
            {
                return new BadRequestObjectResult(new { message = "Não foi possível encontrar o professor informado" });
            }

            professor.Nome = new Nome(model.FirstName, model.LastName);
            professor.Email = new Email(model.Email);
            professor.Salario = model.Salario;

            var curso = await _cursoRepository.GetById(model.CursoId);

            if (curso == null)
            {
                return new BadRequestObjectResult(new { message = "Não foi possível encontrar o curso informado" });
            }

            professor.CursoId = curso.Id;
            professor.Curso = curso;

            var response = await _professorRepository.Atualizar(professor);
            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new ProfessorView(professor));
        }

        public async Task<ActionResult<IEnumerable<ProfessorSimpleView>>> GetAll(System.Guid idCurso)
        {
            var professores = await _professorRepository.GetByCourseId(idCurso);

            if (professores == null)
            {
                return new NotFoundResult();
            }

            var views = professores.Select(c => new ProfessorSimpleView(c)).ToList();

            return new OkObjectResult(views);
        }

        public async Task<ActionResult<ProfessorView>> Obter(System.Guid idProfessor)
        {
            var professor = await _professorRepository.GetById(idProfessor);

            if (professor == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar o professor informado." });
            }

            return new OkObjectResult(new ProfessorView(professor));
        }

        public async Task<ActionResult<ProfessorView>> Registrar(System.Guid idCurso, ProfessorDto model)
        {

            var curso = await _cursoRepository.GetById(model.CursoId);

            if (curso == null)
            {
                return new BadRequestObjectResult(new { message = "Não foi possível encontrar o curso informado" });
            }


            var professor = new ProfessorBuilder()
                .Nome(model.FirstName, model.LastName)
                .Email(model.Email)
                .Salario(model.Salario)
                .Curso(curso)
                .Build();


            var response = await _professorRepository.Cadastrar(professor);

            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new ProfessorView(professor));
        }

        public async Task<ActionResult<bool>> Remover(System.Guid idProfessor)
        {
            var professor = await _professorRepository.GetById(idProfessor);

            if (professor == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar o professor informado." });
            }

            var response = await _professorRepository.Remover(professor);

            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new { message = "Professor removido com sucesso!" });
        }
    }
}
