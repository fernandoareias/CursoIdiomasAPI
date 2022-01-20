using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.ValueObjects;

namespace CursoIdiomas.Domain.Builders
{
    public class ProfessorBuilder
    {
        private readonly Professor _professor;

        public ProfessorBuilder()
        {
            _professor = new Professor();
        }

        public ProfessorBuilder Nome(string firstName, string lastName)
        {
            _professor.Nome = new Nome(firstName, lastName);
            return this;
        }

        public ProfessorBuilder Email(string address)
        {
            _professor.Email = new Email(address);
            return this;
        }
        public ProfessorBuilder Salario(decimal salario)
        {
            _professor.Salario = salario;
            return this;
        }

        public ProfessorBuilder Curso(Curso curso)
        {
            _professor.CursoId = curso.Id;
            _professor.Curso = curso;
            return this;
        }

        public Professor Build()
        {
            return _professor;
        }
    }
}
