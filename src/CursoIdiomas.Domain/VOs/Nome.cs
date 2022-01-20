using System.Collections.Generic;

namespace CursoIdiomas.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        protected Nome()
        {

        }

        public Nome(string firstName, string lastName)
        {

            this.FirstName = firstName;
            this.LastName = lastName;

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }


    }
}
