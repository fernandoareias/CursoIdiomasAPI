using CursoIdiomas.Domain.Entities;

namespace CursoIdiomas.Domain.Builders
{
    public class MatriculaBuilder
    {
        private readonly Matricula _matricula;

        public MatriculaBuilder()
        {
            _matricula = new Matricula();


        }

        public MatriculaBuilder Turma(Turma turma)
        {
            _matricula.TurmaId = turma.Id;
            _matricula.Turma = turma;
            return this;
        }

        public MatriculaBuilder Aluno(Alunos aluno)
        {
            _matricula.AlunoId = aluno.Id;
            _matricula.Aluno = aluno;
            return this;
        }

        public Matricula Build()
        {
            return _matricula;
        }
    }
}
