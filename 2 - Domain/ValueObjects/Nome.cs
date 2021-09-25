using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.ValueObjects
{
   public class Nome : ValueObject, IEquatable<Nome>
    {
        public Nome(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(firstName, 2, "FirstName", "O Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(firstName, 80, "FirstName", "O Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(lastName, 2, "LastName", "O Sobrenome deve ser maior que 2 caractéres.")
                .IsLowerThan(lastName, 80, "LastName", "O Sobrenome deve ser menor que 80 caractéres.")
                );
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Equals(Nome other) => (FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName));
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
