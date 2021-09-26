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

        public DateTime? DataPublicacao { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }
        public float Nota { get; private set; }

        public Guid MatriculaId { get; private set; }
        public Turma Matricula { get; private set; }
    }
}
