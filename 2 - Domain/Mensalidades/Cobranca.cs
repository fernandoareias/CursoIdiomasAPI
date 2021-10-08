using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Cobranca : Entity
    {
        public Cobranca() {

        }
        public Cobranca(DateTime vencimento, decimal valor, string uri, long idAluno) {
            Vencimento = vencimento;
            Valor = valor;
            Uri = uri;
            AlunoId = idAluno;
        }



        public DateTime Vencimento { get; private set; }
        public decimal Valor { get; private set; }
        public string Uri { get; private set; }
        public long AlunoId { get; private set; }
        public Alunos Aluno { get; private set; }
    }
}
