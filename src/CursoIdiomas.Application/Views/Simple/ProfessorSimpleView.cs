namespace CursoIdiomas.Domain.Professor.View.Simple
{
    public class ProfessorSimpleView
    {
        public System.Guid Id { get; set; }
        public string Nome { get; set; }

        public ProfessorSimpleView(CursoIdiomas.Domain.Entities.Professor professor)
        {
            Id = professor.Id;
            Nome = professor.Nome.ToString();
        }
    }
}
