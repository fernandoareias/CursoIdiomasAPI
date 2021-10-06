using CursoIdiomas.Domain.Cursos.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Turma : Entity
    {
        private readonly List<Matricula> _matriculas;
        public Turma() {
            _matriculas = new List<Matricula>();
        }

        public Turma(long professorId, int turno) {

            ProfessorId = professorId;
            Turno = turno;
        }
        public Turma(long id, long idProfessor, int turno) : base(id) {
            ProfessorId = idProfessor;
            Turno = turno;
        }


        public long ProfessorId { get; private set; }
        public CursoIdiomas.Domain.Entities.Professor Professor { get; private set; }
        public int Turno { get; private set; }


        public IEnumerable<Matricula> Matriculas => _matriculas;
        public void AddMatricula(Matricula matricula) {

            _matriculas.Add(matricula);
        }

        public int GetQntAlunos() => _matriculas.Count();
    }
}
