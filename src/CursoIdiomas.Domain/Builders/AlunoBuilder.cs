using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.ValueObjects;

namespace CursoIdiomas.Domain.Builders
{
    public class AlunoBuilder
    {
        private readonly Alunos _aluno;

        public AlunoBuilder()
        {
            _aluno = new Alunos();
        }

        public AlunoBuilder Nome(string firstName, string lastName)
        {
            _aluno.Nome = new Nome(firstName, lastName);
            return this;
        }

        public AlunoBuilder Email(string address)
        {
            _aluno.Email = new Email(address);
            return this;
        }

        public AlunoBuilder Matricular(Turma turma)
        {
            var matricula = new MatriculaBuilder()
                .Turma(turma)
                .Aluno(_aluno)
                .Build();

            _aluno.Matriculas.Add(matricula);
            return this;
        }

        public Alunos Build()
        {
            return _aluno;
        }
    }
}
