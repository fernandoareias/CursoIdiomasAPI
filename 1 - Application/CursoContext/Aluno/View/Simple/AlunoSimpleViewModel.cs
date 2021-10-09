using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Aluno.View.Simple {
    public class AlunoSimpleViewModel {
        public long Id { get; set; }
        public string Nome { get; set; }

        public AlunoSimpleViewModel(Domain.Entities.Alunos entity) {
            Id = entity.Id;
            Nome = entity.Nome.ToString();
        }
    }
}
