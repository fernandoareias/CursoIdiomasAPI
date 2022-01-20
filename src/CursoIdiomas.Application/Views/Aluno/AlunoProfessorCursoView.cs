using CursoIdiomas.Domain.Entities;
using System;

namespace CursoIdiomas.Application.Views.Aluno
{
    public class AlunoProfessorCursoView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public AlunoProfessorCursoView(Curso curso)
        {
            Id = curso.Id;
            Nome = curso.Nome;
            CargaHoraria = curso.CargaHoraria;
            DataInicio = curso.DataInicio;
            DataTermino = curso.DataTermino;
        }
    }
}
