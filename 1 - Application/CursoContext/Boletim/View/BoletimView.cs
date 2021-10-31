using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Boletim {
    public class BoletimView {
        public BoletimView(Domain.Entities.Boletim entity) {
            Nota = entity.Nota;
            DataInclusao = entity.DataPublicacao;
            UltimaAlteracao = entity.UltimaAtualizacao;
        }

        public double Nota { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? UltimaAlteracao { get; set; }


    }
}
