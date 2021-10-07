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
        private List<Matricula> _matriculas;
        public Alunos() {
            _matriculas = new List<Matricula>();
        }
        public Alunos(string FirstName, string LastName, string email, long idTurma) {
            Nome = new Nome(FirstName, LastName);
            Email = new Email(email);
            this.Matricular(idTurma);
        }
        public Alunos(Nome nome, Email email) {
            Nome = nome;
            Email = email;

            _matriculas = new List<Matricula>();
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        
        public IEnumerable<Matricula> Matriculas { get { return _matriculas; } }
        private void AddMatricula(Matricula matricula) {
        if(_matriculas == null) {
                _matriculas = new List<Matricula>();
            }
            _matriculas.Add(matricula);
        }

        public IEnumerable<Cobranca> Cobrancas { get; private set; }
        public IEnumerable<Boletim> Boletims { get; private set; }

        public void Matricular(long idTurma) {
            var matricula = new Matricula(Id,idTurma);
            
            this.AddMatricula(matricula);
        }

        public void Update(Domain.Entities.Alunos model) {
            Nome = model.Nome;
            Email = model.Email;
        }


    }
}
