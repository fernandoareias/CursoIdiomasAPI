using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Views
{
    public class CursoViewCreate
    {
        public string Nome { get; private set; }
        public int Dificuldade { get; set; }
        public int CargaHoraria { get; private set; }
        

        public CursoViewCreate(Curso model)
        {
            Nome = model.Nome;
            Dificuldade = (int)model.Dificuldade;
            CargaHoraria = model.CargaHoraria;
            
        }
    }
}
