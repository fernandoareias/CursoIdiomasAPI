using CursoIdiomas.Application.CursoContext.Professor.View.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Turma.View {
    public class TurmaView {
        public long Id { get; set; }
        public int Turno { get; set; }
        public int QntAlunos { get; set; }
        public ProfessorSimpleViewModel Professor { get; set; }
        

        public TurmaView(Domain.Entities.Turma entity) {
            Id = entity.Id;
            Turno = entity.Turno;
            Professor = new ProfessorSimpleViewModel(entity.Professor);
            QntAlunos = entity.GetQntAlunos();
        }


    }
}
