using CursoIdiomas.Domain.ValueObjects;
using System.Collections.Generic;

namespace CursoIdiomas.Domain.Entities
{
    public class Alunos : Entity
    {
        public Alunos()
        {

        }


        public Nome Nome { get; set; }
        public Email Email { get; set; }

        public List<Matricula> Matriculas { get; set; }
        public IEnumerable<Mensalidade> Mensalidades { get; set; }
        public IEnumerable<Boletim> Boletims { get; set; }

        public string ObtemNomeCompleto()
        {
            return Nome.ToString();
        }

    }
}
