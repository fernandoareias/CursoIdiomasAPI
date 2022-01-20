using CursoIdiomas.Domain.Entities;
using System.Linq;

namespace CursoIdiomas.Application.Views
{
    public class TurmaView
    {
        public System.Guid Id { get; set; }
        public ProfessorView Professor { get; set; }
        public int Turno { get; set; }
        public int QntAlunos { get; set; }

        public TurmaView(Turma turma)
        {
            Id = turma.Id;
            Professor = new ProfessorView(turma.Professor);
            Turno = (int)turma.Turno;
            QntAlunos = turma.Matriculas.Count();
        }
    }
}
