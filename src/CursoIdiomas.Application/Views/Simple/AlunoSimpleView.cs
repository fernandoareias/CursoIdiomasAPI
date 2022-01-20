using CursoIdiomas.Domain.Entities;

namespace CursoIdiomas.Application.Views.Simple
{
    public class AlunoSimpleView
    {
        public System.Guid Id { get; set; }
        public string Nome { get; set; }
        public AlunoSimpleView(Alunos aluno)
        {
            Id = aluno.Id;
            Nome = aluno.Nome.ToString();
        }
    }
}
