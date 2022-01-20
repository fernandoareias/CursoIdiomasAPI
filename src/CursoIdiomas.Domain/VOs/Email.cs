using System.Collections.Generic;

namespace CursoIdiomas.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        protected Email() { }

        public Email(string address)
        {
            this.Address = address;
        }

        public string Address { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {

            yield return Address;
        }
    }
}
