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
        public Nome() {

        }

        public Nome(string firstName, string lastName)
        {

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(firstName, 2, "FirstName", "O primeiro nome deve ser maior que 2 caractéres.")
                .IsLowerThan(firstName, 80, "FirstName", "O primeiro nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(lastName, 2, "LastName", "O segundo nome horaria deve ser maior que 0.")
                .IsLowerThan(lastName, 80, "LastName", "O segundo nome deve ser menor que 4")
                .IsNotNullOrEmpty(firstName, "FirstName", "FirstNome não pode ser null ou void")
                .IsNotNullOrEmpty(lastName, "LastName", "LastName não pode ser null ou void")
                );

            FirstName = firstName;
            LastName = lastName;
            

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public bool Equals(Nome other) => (FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName));
        public override string ToString() => $"{FirstName} {LastName}";

        protected override IEnumerable<object> GetAtomicValues() {
            yield return FirstName;
            yield return LastName;
        }
    }
}
