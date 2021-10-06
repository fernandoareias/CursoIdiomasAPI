using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Cursos.DTO
{
    public class CursoDTO
    {
        public string Nome { get; set; }
        public int Dificuldade { get; set; }
        public int CargaHoraria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }

    }
}
