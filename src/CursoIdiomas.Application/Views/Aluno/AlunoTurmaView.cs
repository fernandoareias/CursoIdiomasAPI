using CursoIdiomas.Domain.Entities;
using System;

namespace CursoIdiomas.Application.Views.Aluno
{
    public class AlunoTurmaView
    {
        public Guid Id { get; set; }
        public int Turno { get; set; }
        public AlunoProfessorView Professor { get; set; }
        public AlunoTurmaView(Turma turma)
        {
            Id = turma.Id;
            Turno = (int)turma.Turno;
            Professor = new AlunoProfessorView(turma.Professor);
        }
    }
}
