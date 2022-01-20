namespace CursoIdiomas.Domain.Professor.View.Simple
{
    public class ProfessorSimpleListViewModel
    {
        public System.Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public ProfessorSimpleListViewModel(Domain.Entities.Professor entity)
        {
            Id = entity.Id;
            Nome = entity.Nome.ToString();
            Email = Email.ToString();
        }
    }
}
