using CursoIdiomas.Domain.Cursos.Enum;
using System;
using System.Collections.Generic;

namespace CursoIdiomas.Domain.Entities
{
    public class Curso : Entity
    {
        public string Nome { get; set; }
        public EDificuldade Dificuldade { get; set; }
        public int CargaHoraria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }

        public virtual IEnumerable<Professor> Professores { get; private set; }


    }
}
