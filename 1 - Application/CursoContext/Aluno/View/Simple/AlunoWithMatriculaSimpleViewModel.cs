using CursoIdiomas.Application.CursoContext.Matricula.View.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Aluno.View.Simple {
    public class AlunoWithMatriculaSimpleViewModel {
        public long Id { get; set; }
        public string Nome { get; set; }
        public List<MatriculaSimpleViewModel> Matriculas { get; set; }
        public AlunoWithMatriculaSimpleViewModel(Domain.Entities.Alunos entity) {
            Id = entity.Id;
            Nome = entity.Nome.ToString();
            Matriculas = MatriculaSimpleViewModel.Map(entity.Matriculas);
        }
    }
}
