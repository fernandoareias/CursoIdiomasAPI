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
        public Professor(Nome nome, Email email)
        {
            Nome = nome;
            Email = email;

        //    AddNotifications(new Contract<Notification>()
            //    .Requires()
            //);
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }

        public Guid TurmaId { get; private set; }
        public Turma Turma { get; private set; }

    }
}
