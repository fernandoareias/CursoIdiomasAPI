using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace CursoIdiomas.Domain.Entities
{
    public class Boletim : Entity
    {
        public Boletim() { }
        public Boletim(double nota, long idAluno) {
            Nota = nota;
            DataPublicacao = System.DateTime.Now;
            IdAluno = idAluno;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(nota, 0.0, "Nota", "Nota Invalida.")
                .IsLowerThan(nota, 10.1, "Nota", "Nota Invalida.")
                .IsGreaterThan(idAluno, 0, "Aluno", "Aluno inválido.")
            );

        }

        public void UpdateDate() => UltimaAtualizacao = System.DateTime.Now;

        public DateTime? DataPublicacao { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }
        public double Nota { get; private set; }

        public long IdAluno { get; private set; }
        public Alunos Aluno { get; private set; }
    }
}
