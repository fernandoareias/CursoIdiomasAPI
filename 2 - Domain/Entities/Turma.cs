using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Turma : Entity
    {
        public Turma() { }

        public Turma(DateTime? dataInicio, DateTime? dataFim) {
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public DateTime? DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }


        public Guid CursoId { get; private set; }
        public Curso Curso { get; private set; }
        public Guid ProfessorId { get; private set; }
        public CursoIdiomas.Domain.Professor.Professor Professor { get; private set; }

        public virtual List<Matricula> Matriculas { get; set; }
    }
}
