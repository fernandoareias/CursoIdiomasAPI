using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Views
{
    public class CursoView
    {
        public string Nome { get;  set; }
        public int Dificuldade { get; set; }
        public int CargaHoraria { get;  set; }


        public CursoView(Curso model)
        {
            Nome = model.Nome;
            Dificuldade = (int)model.Dificuldade;
            CargaHoraria = model.CargaHoraria;

        }

        public static async Task<IEnumerable<CursoView>> Mapping(IEnumerable<Curso> cursos)
        {
            var listCursos = new List<CursoView>();
            foreach(var curso in cursos)
            {
                var cursoModel = new CursoView(curso);
                listCursos.Add(cursoModel);
            }

            return await Task.FromResult(listCursos);
        }
    }
}
