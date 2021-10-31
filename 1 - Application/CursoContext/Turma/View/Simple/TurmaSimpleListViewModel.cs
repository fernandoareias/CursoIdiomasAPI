using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Turma.View.Simple {
    public class TurmaSimpleListViewModel {
        public long Id { get; set; }
        public int Turno { get; set; }
        public int QntAlunos { get; set; }

        public TurmaSimpleListViewModel(Domain.Entities.Turma entity) {
            Id = entity.Id;
            Turno = entity.Turno;
            QntAlunos = entity.GetQntAlunos();
        }
    }
}
