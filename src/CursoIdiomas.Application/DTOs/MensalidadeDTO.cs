using System;

namespace CursoIdiomas.Domain.Mensalidades.DTOs
{
    public class MensalidadeDTO
    {
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
        public string Uri { get; set; }
    }
}
