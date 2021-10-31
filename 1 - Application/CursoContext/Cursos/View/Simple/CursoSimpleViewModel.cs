using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Cursos.View.Simple {
    public class CursoSimpleViewModel {
        public long Id { get; set; }
        public string Nome { get; set; }


        public CursoSimpleViewModel(Domain.Cursos.Curso.Curso entity) {
            Id = entity.Id;
            Nome = entity.Nome.ToString();
        }
        

    }
}
