using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Matricula : Entity
    {
        public Matricula() {

        }
        public bool Ativa { get;  set; }

        public Guid AlunoId { get; set; }
        public  Alunos Aluno { get;  set; }
        public Guid TurmaId { get; set; }
        public  Turma Turma { get;  set; }
        public virtual List<Boletim> Boletins { get;  set; }
        public virtual List<Mensalidade> Mensalidades { get;  set; }

    }
}
