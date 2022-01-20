using CursoIdiomas.Application.Views;
using CursoIdiomas.Application.Views.Simple;
using CursoIdiomas.Domain.Application.Interfaces;
using CursoIdiomas.Domain.Builders;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Domain.Turma.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IProfessorRepository _professorRepository;

        public TurmaService(
            ITurmaRepository turmaRepository,
            IProfessorRepository professorRepository
        )
        {
            _turmaRepository = turmaRepository;
            _professorRepository = professorRepository;
        }

        public async Task<ActionResult<TurmaView>> Atualizar(System.Guid id, TurmaDto model)
        {
            var turma = await _turmaRepository.GetById(id);

            if (turma == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar a turma informada" });
            }


            var professor = await _professorRepository.GetById(model.ProfessorId);
            if (professor == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar o professor informado." });
            }

            turma.Turno = (Domain.Enum.ETurno)model.Turno;
            turma.Professor = professor;
            turma.ProfessorId = professor.Id;

            var response = await _turmaRepository.Update(turma);
            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new TurmaView(turma));

        }

        public async Task<ActionResult<IEnumerable<TurmaSimpleView>>> GetAllByProfessor(System.Guid idProfessor)
        {
            var turmas = await _turmaRepository.GetByProfessorId(idProfessor);
            if (turmas == null)
            {
                return new NotFoundObjectResult(new { message = "O Professor informado não possui turma ativa." });
            }
            var views = turmas.Select(t => new TurmaSimpleView(t)).ToList();

            return new OkObjectResult(views);
        }

        public async Task<ActionResult<TurmaView>> Registrar(System.Guid idProfessor, TurmaDto model)
        {

            var professor = await _professorRepository.GetById(idProfessor);


            var turma = new TurmaBuilder()
                            .Professor(professor)
                            .Turno(model.Turno)
                            .Build();

            var response = await _turmaRepository.Create(turma);

            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new TurmaView(turma));
        }

        public async Task<ActionResult<bool>> Remover(System.Guid id)
        {
            var turma = await _turmaRepository.GetById(id);

            if (turma == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar a turma informada" });
            }

            if (turma.Matriculas.Any(m => m.Status == Domain.Enums.EMatriculaStatus.Ativo))
            {
                return new BadRequestObjectResult(new { message = "Não é possível deletar uma turma que possuí aluno ativo." });
            }

            var response = await _turmaRepository.Delete(turma);

            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new { message = "Turma removida com sucesso!" });
        }

        public async Task<ActionResult<TurmaView>> Visualizar(System.Guid id)
        {
            var turma = await _turmaRepository.GetById(id);

            if (turma == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar a turma informada." });
            }

            return new OkObjectResult(new TurmaView(turma));
        }
    }
}
