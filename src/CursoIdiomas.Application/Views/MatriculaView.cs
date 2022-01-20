using CursoIdiomas.Domain.Entities;
using System;

namespace CursoIdiomas.Application.Views
{
    public class MatriculaView
    {
        public Guid Id { get; set; }
        public MatriculaView(Matricula matricula)
        {
            Id = matricula.Id;
        }
    }
}
