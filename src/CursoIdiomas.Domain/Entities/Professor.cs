using CursoIdiomas.Domain.ValueObjects;
using System.Collections.Generic;

namespace CursoIdiomas.Domain.Entities
{
    public class Professor : Entity
    {

        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public decimal Salario { get; set; }


        public System.Guid CursoId { get; set; }
        public Curso Curso { get; set; }

        public IEnumerable<Turma> Turmas { get; set; }



    }
}
