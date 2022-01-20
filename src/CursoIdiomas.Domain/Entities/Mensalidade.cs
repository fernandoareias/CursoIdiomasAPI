using System;

namespace CursoIdiomas.Domain.Entities
{
    public class Mensalidade : Entity
    {
        public DateTime Vencimento { get; private set; }
        public decimal Valor { get; private set; }
        public string Uri { get; private set; }
        public System.Guid AlunoId { get; private set; }
        public Alunos Aluno { get; private set; }
    }
}
