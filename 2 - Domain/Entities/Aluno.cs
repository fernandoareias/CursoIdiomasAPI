using CursoIdiomas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Alunos : Entity
    {
        public Alunos() { }

        public Alunos(Nome nome, Email email) {
            Nome = nome;
            Email = email;
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }

        public Matricula Matricula { get; private set; }
    }
}
