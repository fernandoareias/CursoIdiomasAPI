using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Mensalidades.DTOs {
    public class MensalidadeView {
        public decimal Valor { get; set; }
        public string URI { get; set; }
        public DateTime DataVencimento { get; set; }

    
    }
}
