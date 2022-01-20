namespace CursoIdiomas.Application.Views
{
    public class ProfessorView
    {
        public System.Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
        public CursoView Curso { get; set; }

        public ProfessorView(Domain.Entities.Professor professor)
        {
            Id = professor.Id;
            Nome = professor.Nome.ToString();
            Salario = professor.Salario;
            Email = professor.Email.Address;
            Curso = new CursoView(professor.Curso);
        }
    }
}
