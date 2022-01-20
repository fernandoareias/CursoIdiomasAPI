using CursoIdiomas.Domain.Entities;
using System;

namespace CursoIdiomas.Application.Views.Aluno
{
    public class AlunoMatriculaView
    {

        public Guid Id { get; set; }
        public AlunoTurmaView Turma { get; set; }
        public int Status { get; set; }
        public AlunoMatriculaView(Matricula matricula)
        {
            Id = matricula.Id;
            Status = (int)matricula.Status;
        }
    }
}
