using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public class Boletim : Entity
    {
        public Boletim() { }
        public Boletim(float nota) {
            Nota = nota;
            DataPublicacao = System.DateTime.Now;
        }

        public void UpdateDate() => UltimaAtualizacao = System.DateTime.Now;

        public DateTime? DataPublicacao { get;  set; }
        public DateTime? UltimaAtualizacao { get;  set; }
        public float Nota { get;  set; }

        public Guid MatriculaId { get;  set; }
        public Matricula Matricula { get;  set; }
    }
}
