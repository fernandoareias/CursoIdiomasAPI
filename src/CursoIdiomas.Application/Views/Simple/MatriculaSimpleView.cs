using CursoIdiomas.Domain.Entities;
using System;

namespace CursoIdiomas.Application.Views.Simple
{
    public class MatriculaSimpleView
    {
        public Guid Id { get; set; }
        public TurmaSimpleView Turma { get; set; }

        public MatriculaSimpleView(Matricula matricula)
        {
            Id = matricula.Id;
            Turma = new TurmaSimpleView(matricula.Turma);
        }
    }
}
