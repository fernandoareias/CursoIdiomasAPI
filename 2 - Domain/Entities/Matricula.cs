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

        public Matricula(long alunoId, long turmaId) {
            AlunoId = alunoId;
            TurmaId = turmaId;
        }

        public long AlunoId { get; private set; }
        public  Alunos Aluno { get; private set; }
        public long TurmaId { get; private set; }
        public  Turma Turma { get; private set; }
        

    }
}
