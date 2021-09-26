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

        public Matricula(bool ativa, Guid alunoId, Guid turmaId) {
            Ativa = ativa;
            AlunoId = alunoId;
            TurmaId = turmaId;
        }

        public bool Ativa { get; private set; }

        public Guid AlunoId { get; private set; }
        public  Alunos Aluno { get; private set; }
        public Guid TurmaId { get; private set; }
        public  Turma Turma { get; private set; }
        public virtual List<Boletim> Boletins { get; private set; }
        public virtual List<Mensalidade> Mensalidades { get; private set; }

    }
}
