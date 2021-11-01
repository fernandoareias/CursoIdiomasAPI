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
            CursoId = idCurso;
        }

        public Professor(string FirstName, string LasName, string Address, decimal salario, long idCurso) {
            Professor_Nome = new Nome(FirstName, LasName);
            Professor_Email = new Email(Address);
            Salario = salario;
            CursoId = idCurso;
        }

        public Professor(long id, Nome professor_Nome, Email professor_Email, decimal salario, long idCurso) : base(id) {
            Professor_Nome = professor_Nome;
            Professor_Email = professor_Email;
            Salario = salario;
            CursoId = idCurso;
        }

        public Professor(Nome professor_Nome, Email professor_Email, decimal salario, long idCurso) {
            Professor_Nome = professor_Nome;
            Professor_Email = professor_Email;
            Salario = salario;
            CursoId = idCurso;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(salario, 0, "Salario", "O salario deve ser maior que 0.")
                .IsGreaterThan(idCurso, 0, "IdCurso", "Id do curso inválido.")
                .IsNotNull(professor_Nome, "Nome", "Nome não pode ser null")
                .IsNotNull(professor_Email, "Email", "Email não pode ser null")
            );
        }

       

        public Professor(long id, Nome professor_Nome, Email professor_Email) : base(id) {
            Professor_Nome = professor_Nome;
            Professor_Email = professor_Email;
        }

        public Professor(long id, Nome professor_Nome, Email professor_Email, long idCurso) : base(id) {
            Professor_Nome = professor_Nome;
            Professor_Email = professor_Email;
            CursoId = idCurso;
        }
        public  Nome Professor_Nome { get; private set; }
        public  Email Professor_Email { get; private set; }
        public decimal Salario { get; private set; }


        public long CursoId { get; private set; }
        public Curso Curso { get; private set; }
        
        public IEnumerable<Turma> Turmas { get; private set; }

        public void Update(Professor entity) {
            
            Professor_Nome = entity.Professor_Nome;
            Professor_Email = entity.Professor_Email;
            Salario = entity.Salario;
            CursoId = entity.CursoId;
        }

    }
}
