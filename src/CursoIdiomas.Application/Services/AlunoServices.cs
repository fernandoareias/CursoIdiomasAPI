using CursoIdiomas.Application.Views;
using CursoIdiomas.Application.Views.Simple;
using CursoIdiomas.Domain.Aluno.DTOs;
using CursoIdiomas.Domain.Application.Interfaces;
using CursoIdiomas.Domain.Builders;
using CursoIdiomas.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Services
{
    public class AlunosServices : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;

        public AlunosServices(
            IAlunoRepository alunoRepository,
            ITurmaRepository turmaRepository
        )
        {
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;

        }

        public async Task<ActionResult<AlunoView>> Atualizar(System.Guid idAluno, AlunoDto model)
        {
            var aluno = await _alunoRepository.GetById(idAluno);

            if (aluno == null)
            {
                return new BadRequestObjectResult(new { message = "Não foi possível encontrar o aluno informado" });
            }

            aluno.Nome = new Domain.ValueObjects.Nome(model.FirstName, model.LastName);
            aluno.Email = new Domain.ValueObjects.Email(model.Email);

            var response = await _alunoRepository.Update(aluno);

            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new AlunoView(aluno));
        }

        public async Task<ActionResult<IEnumerable<AlunoSimpleView>>> GetAll()
        {
            var alunos = await _alunoRepository.GetAll();
            if (alunos == null)
            {
                return new NotFoundResult();
            }

            var views = alunos.Select(a => new AlunoSimpleView(a)).ToList();

            return new OkObjectResult(views);
        }

        public async Task<ActionResult<AlunoView>> Obter(System.Guid id)
        {
            var aluno = await _alunoRepository.GetById(id);

            if (aluno == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar o aluno informado." });
            }

            return new OkObjectResult(new AlunoView(aluno));
        }

        public async Task<ActionResult<AlunoView>> Registrar(System.Guid idTurma, AlunoDto model)
        {
            var turma = await _turmaRepository.GetById(idTurma);
            if (turma == null)
            {
                return new BadRequestObjectResult(new { message = "Não foi possível encontrar a turma informada" });
            }

            if (turma.Matriculas.Count() >= 10)
            {
                return new BadRequestObjectResult(new { message = "Ops. A turma informada não possuí vaga :(" });
            }

            var aluno = new AlunoBuilder()
                .Nome(model.FirstName, model.LastName)
                .Email(model.Email)
                .Matricular(turma)
                .Build();


            var response = await _alunoRepository.Create(aluno);

            if (response == null)
            {
                return new BadRequestObjectResult(aluno);
            }

            return new OkObjectResult(new AlunoView(aluno));
        }

        public async Task<ActionResult<object>> Remover(System.Guid id)
        {
            var aluno = await _alunoRepository.GetById(id);

            if (aluno == null)
            {
                return new NotFoundObjectResult(new { message = "Não foi possível encontrar o aluno informado." });
            }

            var response = await _alunoRepository.Remove(aluno);

            if (response == null)
            {
                return new BadRequestObjectResult(new { message = "Ops.. ocorreu algum erro, tente novamente mais tarde!" });
            }

            return new OkObjectResult(new { message = "Aluno removido com sucesso!" });
        }
    }
}
