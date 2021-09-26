using CursoIdiomas.Domain.Cursos.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Turma : Entity
    {
        


        public DateTime? DataInicio { get;  set; }
        public DateTime? DataFim { get;  set; }
        public Guid CursoId { get; set; }
        public Curso Curso { get;  set; }
        public Guid ProfessorId { get; set; }
        public CursoIdiomas.Domain.Professor.Professor Professor { get;  set; }

        public virtual List<Matricula> Matriculas { get;  set; }
    }
}
