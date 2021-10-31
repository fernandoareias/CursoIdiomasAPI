using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Boletim.DTOs {
    public class BoletimDTO {
        public double Nota { get; set; }


        public Domain.Boletim.DTO.BoletimDTO ToDomain() {
            return new Domain.Boletim.DTO.BoletimDTO() {
                Nota = this.Nota
            };
        }
    }
}
