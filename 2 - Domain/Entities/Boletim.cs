using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Boletim : Entity
    {
        public Boletim() { }
        public Boletim(double nota, long idAluno) {
            Nota = nota;
            DataPublicacao = System.DateTime.Now;
            IdAluno = idAluno;

        }

        public void UpdateDate() => UltimaAtualizacao = System.DateTime.Now;

        public DateTime? DataPublicacao { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }
        public double Nota { get; private set; }

        public long IdAluno { get; private set; }
        public Alunos Aluno { get; private set; }
    }
}
