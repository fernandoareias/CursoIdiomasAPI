
using Flunt.Notifications;
using Flunt.Validations;
using Shared.ValueObjects;

namespace Domain.CourseContext.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            // Verficia se o email está no formato correto
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsEmail(Address, "Email", "O E-mail informado é inválido.")
            );
            Address = address;


        }

        public string Address { get; private set; }


        public override string ToString() => Address;
    }
}