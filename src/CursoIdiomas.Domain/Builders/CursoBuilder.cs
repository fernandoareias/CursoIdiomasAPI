using CursoIdiomas.Domain.Cursos.Enum;
using CursoIdiomas.Domain.Entities;
using System;

namespace CursoIdiomas.Domain.Builders
{
    public class CursoBuilder
    {
        private readonly Curso _curso;

        public CursoBuilder()
        {
            _curso = new Curso();
        }

        public CursoBuilder Nome(string firstName)
        {
            _curso.Nome = firstName;
            return this;
        }

        public CursoBuilder Dificuldade(object dificuldade)
        {
            _curso.Dificuldade = (EDificuldade)dificuldade;
            return this;
        }
        public CursoBuilder CargaHoraria(int cargaHoraria)
        {
            _curso.CargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder DataInicio(DateTime dataInicio)
        {
            _curso.DataInicio = dataInicio;
            return this;
        }
        public CursoBuilder DataTermino(DateTime? dataTermino)
        {
            _curso.DataTermino = dataTermino;
            return this;
        }

        public Curso Build()
        {
            return _curso;
        }
    }
}
