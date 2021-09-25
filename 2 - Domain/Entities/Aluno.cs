using CursoIdiomas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Aluno : Entity
    {

        public Nome Nome { get; set; }
        public Email Email { get; set; }

    }
}
