using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.ValueObjects
{
    public class Email : ValueObject, IEquatable<Email>
    {
        public Email(string address)
        {
            Address = address;
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsEmail(address, "Address", "E-mail inválido")
            );
        }

        public string Address { get; set; }
        public bool Equals(Email other) => Address == other.Address;

    }
}
