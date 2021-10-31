using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace CursoIdiomas.Domain.Entities
{
    public class Mensalidade : Entity
    {
        public Mensalidade() {

        }
        public Mensalidade(DateTime vencimento, decimal valor, string uri, long idAluno) {
            Vencimento = vencimento;
            Valor = valor;
            Uri = uri;
            AlunoId = idAluno;

               AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(uri, "URL", "URL não pode ser null ou vazia.")
                .IsGreaterOrEqualsThan(vencimento, DateTime.Now, "Vencimento", "Data de vencimento Invalido.")
                .IsGreaterThan(valor, 0, "Valor", "Valor da mensaldiade deve ser maior que zero.")
                .IsGreaterThan(uri, 1, "URL", "URL da mensalidade deve ser maior que 0 caractéres.")
                .IsLowerThan(uri, 250, "Nota", "RL da mensalidade deve ser menor que 250 caractéres.")
                .IsGreaterThan(idAluno, 0, "Aluno", "Aluno inválido.")
            );
        }



        public DateTime Vencimento { get; private set; }
        public decimal Valor { get; private set; }
        public string Uri { get; private set; }
        public long AlunoId { get; private set; }
        public Alunos Aluno { get; private set; }
    }
}
