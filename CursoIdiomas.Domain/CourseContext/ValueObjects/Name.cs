
using Flunt.Notifications;
using Flunt.Validations;
using Shared.ValueObjects;

namespace Domain.CourseContext.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            // Verifica se está no range do VARCHAR()
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerThan(firstName, 80, "O nome deve conter até 40 caractéres.")
                .IsGreaterThan(firstName, 3, "O nome deve conter mais de 3 caractér.")
                .IsLowerThan(lastName, 80, "O nome deve conter até 40 caractéres.")
                .IsGreaterThan(lastName, 3, "O nome deve conter mais de 3 caractér.")
            );

            FirstName = firstName;
            LastName = lastName;

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        public override string ToString() => $"{FirstName} {LastName}";

    }
}