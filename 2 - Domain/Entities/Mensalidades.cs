using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Mensalidades : Entity
    {
        public DateTime Vencimento { get; private set; }
        public decimal Valor { get; private set; }
        public Guid MatriculaId { get; private set; }
        public Matricula Matricula { get; private set; }
    }
}
