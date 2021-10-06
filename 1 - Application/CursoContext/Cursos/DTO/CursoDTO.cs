using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Cursos.DTO
{
    public class CursoDTO
    {
        public string Nome { get; set; }
        public int Dificuldade { get; set; }
        public int CargaHoraria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public CursoIdiomas.Domain.Cursos.DTO.CursoDTO ToDomain()
        {
            return new Domain.Cursos.DTO.CursoDTO
            {
                Nome = this.Nome,
                Dificuldade = this.Dificuldade,
                CargaHoraria = this.CargaHoraria,
                DataInicio = this.DataInicio,
                DataTermino = this.DataTermino
            };
        }
    }
}
