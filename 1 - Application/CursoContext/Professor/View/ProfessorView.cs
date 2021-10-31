using CursoIdiomas.Application.CursoContext.Cursos.View.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Professor.View {
    public class ProfessorView {

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public CursoSimpleViewModel Curso { get; set; }
        // Revisar

        public ProfessorView(Domain.Entities.Professor entity) {
            Id = entity.Id;
            Nome = entity.Professor_Nome.ToString();
            Email = entity.Professor_Email.ToString();
            Curso = new CursoSimpleViewModel(entity.Curso);
        }
       
    }
}
