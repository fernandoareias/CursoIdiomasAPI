using CursoIdiomas.Domain.Enum;
using System.Collections.Generic;

namespace CursoIdiomas.Domain.Entities
{
    public class Turma : Entity
    {

        public Turma()
        {

        }



        public System.Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public ETurno Turno { get; set; }
        public IEnumerable<Matricula> Matriculas { get; set; }

    }
}
