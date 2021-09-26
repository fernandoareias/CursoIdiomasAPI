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
        public Email() {

        }
        public Email(string address)
        {
            Address = address;
           
        }

        public string Address { get; private set; }
        public bool Equals(Email other) => Address == other.Address;

        public override string ToString() => Address;

        protected override IEnumerable<object> GetAtomicValues() {
            // Using a yield return statement to return each element one at a time
            yield return Address;
        }
    }
}
