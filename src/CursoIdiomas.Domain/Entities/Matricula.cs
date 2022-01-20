using CursoIdiomas.Domain.Enums;

namespace CursoIdiomas.Domain.Entities
{
    public class Matricula : Entity
    {
        public Matricula()
        {
            Status = EMatriculaStatus.Ativo;
        }

        public EMatriculaStatus Status { get; set; }
        public System.Guid AlunoId { get; set; }
        public Alunos Aluno { get; set; }
        public System.Guid TurmaId { get; set; }
        public Turma Turma { get; set; }

    }
}
