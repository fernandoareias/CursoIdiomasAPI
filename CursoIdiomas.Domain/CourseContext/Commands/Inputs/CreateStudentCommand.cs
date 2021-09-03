

using Domain.CourseContext.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.CourseContext.Commands.Inputs
{
    public class CreateStudentCommands : Notifiable<Notification>, ICommands
    {
        public CreateStudentCommands() { }
        public CreateStudentCommands(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsEmail(Email, "Email", "O Email é inválido.")
                .IsLowerThan(FirstName, 80, "FirstName", "O Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(FirstName, 2, "FirstName", "O Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(LastName, 80, "LastName", "O Sobrenome deve conter no máximo 80 caractéres,")
                .IsGreaterThan(LastName, 2, "LastName", "O Sobrenome deve ser maior que 2 caractéres.")
            );

            return IsValid;
        }
    }
}