using CursoIdiomas.Application.CursoContext.Cursos.View.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Professor.View.Simple {
    public class ProfessorSimpleViewModel {
        public string Nome { get; set; }
        public string Email { get; set; }


        public ProfessorSimpleViewModel(Domain.Entities.Professor entity) {
            Nome = entity.Professor_Nome.ToString();
            Email = entity.Professor_Email.ToString();            
        }
    }
}
