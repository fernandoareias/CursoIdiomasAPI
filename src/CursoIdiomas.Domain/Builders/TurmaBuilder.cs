using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Enum;

namespace CursoIdiomas.Domain.Builders
{
    public class TurmaBuilder
    {
        private readonly Turma _turma;


        public TurmaBuilder()
        {
            _turma = new Turma();
        }

        public TurmaBuilder Professor(Professor professor)
        {
            _turma.ProfessorId = professor.Id;
            _turma.Professor = professor;
            return this;
        }

        public TurmaBuilder Turno(object turno)
        {
            _turma.Turno = (ETurno)turno;
            return this;
        }

        public Turma Build()
        {
            return _turma;
        }
    }
}
