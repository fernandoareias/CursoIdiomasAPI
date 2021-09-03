

using Domain.CourseContext.ValueObjects;
using Flunt.Validations;
using Shared.Entities;
using Flunt.Notifications;

namespace Domain.CourseContext.Entities
{
    public class Student : Entity
    {
        public Student(Name name, Email email)
        {
            Name = name;
            Email = email;
        }


        public Name Name { get; private set; }
        public Email Email { get; private set; }

    }
}