using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Boletim : Entity
    {
        public DateTime? Publicacao { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }
        public float Nota { get; private set; }

        public Guid MatriculaId { get; private set; }
        public Matricula Matricula { get; private set; }
    }
}
