using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Cursos.View.Simple {
    public class CursoSimpleListViewModel {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Dificuldade { get; set; }

        public CursoSimpleListViewModel(Domain.Cursos.Curso.Curso entity) {
            Id = entity.Id;
            Nome = entity.Nome;
            Dificuldade = (int)entity.Dificuldade;
        }
    }
}
