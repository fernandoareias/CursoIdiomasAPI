using CursoIdiomas.Domain.Cursos.Curso;
using CursoIdiomas.Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Professor : Entity
    {
        public Professor() { }

        public Professor(long id, string FirstName, string LasName, string Address, decimal salario, long idCurso) : base(id) {
            Professor_Nome = new Nome(FirstName, LasName);
            Professor_Email = new Email(Address);
            Salario = salario;
            IdCurso = idCurso;
        }

        public Professor(string FirstName, string LasName, string Address, decimal salario, long idCurso) {
            Professor_Nome = new Nome(FirstName, LasName);
            Professor_Email = new Email(Address);
            Salario = salario;
            IdCurso = idCurso;
        }

        public Professor(long id, Nome professor_Nome, Email professor_Email, decimal salario, long idCurso) : base(id) {
            Professor_Nome = professor_Nome;
            Professor_Email = professor_Email;
            Salario = salario;
            IdCurso = idCurso;
        }

        public Professor(Nome professor_Nome, Email professor_Email, decimal salario, long idCurso) {
            Professor_Nome = professor_Nome;
            Professor_Email = professor_Email;
            Salario = salario;
            IdCurso = idCurso;
        }

       

        public Professor(long id, Nome professor_Nome, Email professor_Email) : base(id) {
            Professor_Nome = professor_Nome;
            Professor_Email = professor_Email;
        }

        public  Nome Professor_Nome { get; private set; }
        public  Email Professor_Email { get; private set; }
        public decimal Salario { get; private set; }

        public long IdCurso { get; private set; }
        public Curso Curso { get; private set; }

        public IEnumerable<Turma> Turmas { get; private set; }

    }
}
