using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Matricula : Entity
    {
        public bool Ativa { get; private set; }

        public Guid AlunoId { get; private set; }
        public virtual Aluno Aluno { get; private set; }
        public Guid TurmaId { get; private set; }
        public virtual Turma Turma { get; private set; }

        public virtual List<Boletim> Boletins { get; private set; }
        public virtual List<Mensalidades> Mensalidades { get; private set; }

    }
}
