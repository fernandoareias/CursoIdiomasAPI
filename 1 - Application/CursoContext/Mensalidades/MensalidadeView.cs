using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Mensalidades {
    public class MensalidadeView {
        public decimal Valor { get; set; }
        public string URI { get; set; }
        public DateTime DataVencimento { get; set; }


        public MensalidadeView(Domain.Entities.Mensalidade entity) {
            Valor = entity.Valor;
            URI = entity.Uri;
            DataVencimento = entity.Vencimento;
        }

        public Domain.Mensalidades.DTOs.MensalidadeView ToDomain() {
            return new Domain.Mensalidades.DTOs.MensalidadeView() {
                Valor = this.Valor,
                URI = this.URI,
                DataVencimento = this.DataVencimento
            };
        }
    }
}
