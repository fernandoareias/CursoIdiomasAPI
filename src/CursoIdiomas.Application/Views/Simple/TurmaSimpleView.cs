using CursoIdiomas.Domain.Entities;
using System;

namespace CursoIdiomas.Application.Views.Simple
{
    public class TurmaSimpleView
    {
        public Guid Id { get; set; }
        public int Turno { get; set; }


        public TurmaSimpleView(Turma turma)
        {
            Id = turma.Id;
            Turno = (int)turma.Turno;
        }
    }
}
