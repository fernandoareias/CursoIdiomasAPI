using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Turma.View {
    public class TurmaView {
        public long Id { get; set; }
        public int Turno { get; set; }
        public long ProfessorId { get; set; }


        public TurmaView(Domain.Entities.Turma entity) {
            Id = entity.Id;
            Turno = entity.Turno;
            ProfessorId = entity.ProfessorId;
        }
    }
}
