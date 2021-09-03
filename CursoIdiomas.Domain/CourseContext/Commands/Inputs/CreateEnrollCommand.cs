

using System;
using Domain.CourseContext.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.CourseContext.Commands.Inputs
{
    public class CreateEnrollCommands : Notifiable<Notification>, ICommands
    {
        public CreateEnrollCommands() { }

        public CreateEnrollCommands(Guid student, Guid classe)
        {
            Student = student;
            Classe = classe;
        }

        public System.Guid Student { get; set; }
        public System.Guid Classe { get; set; }


        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
               );

            return IsValid;
        }
    }
}