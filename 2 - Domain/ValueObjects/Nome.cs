﻿using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.ValueObjects
{
   public class Nome :  IEquatable<Nome>
    {
        public Nome(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Equals(Nome other) => (FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName));
        public override string ToString() => $"{FirstName} {LastName}";
    }
}