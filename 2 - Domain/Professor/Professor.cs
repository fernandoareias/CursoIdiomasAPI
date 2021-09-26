using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Professor
{
    public class Professor : Entity
    {
        public Professor() { }

        public Professor(Guid id, string FirstName, string LasName, string Address) : base(id) {
            Professor_Nome = new Nome(FirstName, LasName);
            Professor_Email = new Email(Address);
        }
        public Professor(string FirstName, string LasName, string Address) {
            Professor_Nome = new Nome(FirstName, LasName);
            Professor_Email = new Email(Address);
        }

        public Professor(Guid id, Nome professor_Nome, Email professor_Email) : base(id){
            Professor_Nome = professor_Nome;
            Professor_Email = professor_Email;
        }

        public Professor(Nome professor_Nome, Email professor_Email) {
            Professor_Nome = professor_Nome;
            Professor_Email = professor_Email;
        }
 

        public  Nome Professor_Nome { get; private set; }
        public  Email Professor_Email { get; private set; }
        public  List<Turma> Turmas { get; private set; }

    }
}
