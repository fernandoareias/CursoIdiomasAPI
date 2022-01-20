using System;

namespace CursoIdiomas.Domain.Entities
{
    public class Boletim : Entity
    {

        public DateTime? DataPublicacao { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }
        public double Nota { get; private set; }

        public System.Guid AlunoId { get; private set; }
        public Alunos Aluno { get; private set; }
    }
}
