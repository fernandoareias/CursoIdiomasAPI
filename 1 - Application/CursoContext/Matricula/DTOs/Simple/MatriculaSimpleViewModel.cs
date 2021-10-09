using CursoIdiomas.Application.CursoContext.Aluno.DTOs.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Matricula.View.Simple {
    public class MatriculaSimpleViewModel {

        public long Id { get; set; }

        public AlunoSimpleView Aluno { get; set; }

        public MatriculaSimpleViewModel(Domain.Entities.Matricula entity) {
            Id = entity.Id;
            Aluno = new AlunoSimpleView(entity.Aluno);
        }

        public static List<MatriculaSimpleViewModel> Map(IEnumerable<Domain.Entities.Matricula> entities) {
            var lista = new List<MatriculaSimpleViewModel>();

            foreach(var matricula in entities) {
                lista.Add(new MatriculaSimpleViewModel(matricula));
            }

            return lista;
        }
    }
}
