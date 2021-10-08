using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Mensalidades.DTOs {
    public class MensalidadeDTO {
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
        public string Uri { get; set; }

        public Domain.Mensalidades.DTOs.MensalidadeDTO ToDomain() {
            return new Domain.Mensalidades.DTOs.MensalidadeDTO() {
                Vencimento = this.Vencimento,
                Valor = this.Valor,
                Uri = this.Uri
            };
        }
    }
}
