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
        public bool Ativa { get; private set; }

        public Guid AlunoId { get; private set; }
        public virtual Turma Aluno { get; private set; }
        public Guid TurmaId { get; private set; }
        public virtual Turma Turma { get; private set; }

        public virtual List<Turma> Boletins { get; private set; }
        public virtual List<Turma> Mensalidades { get; private set; }

    }
}
