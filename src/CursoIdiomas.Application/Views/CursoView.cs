using CursoIdiomas.Domain.Entities;
using System;

namespace CursoIdiomas.Application.Views
{
    public class CursoView
    {
        public System.Guid Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int Dificuldade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }

        public CursoView(Curso curso)
        {
            Id = curso.Id;
            Nome = curso.Nome;
            CargaHoraria = curso.CargaHoraria;
            Dificuldade = (int)curso.Dificuldade;
            DataInicio = curso.DataInicio;
            DataTermino = curso.DataTermino;
        }
    }
}
