using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Turma.DTOs {
    public class TurmaDTO {
        public int Turno { get; set; }


        public Domain.Turma.DTO.TurmaDTO ToDomain() {
            return new Domain.Turma.DTO.TurmaDTO() {
                Turno = this.Turno
            };
        }
    }
}
