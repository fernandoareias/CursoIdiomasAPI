using CursoIdiomas.Domain.Entities;

namespace CursoIdiomas.Application.Views.Simple
{
    public class CursoSimpleView
    {
        public System.Guid Id { get; set; }
        public string Nome { get; set; }


        public CursoSimpleView(Curso curso)
        {
            Id = curso.Id;
            Nome = curso.Nome;

        }
    }
}
