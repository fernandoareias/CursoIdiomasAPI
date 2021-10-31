using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Aluno.View {
    public class AlunoView {

        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Domain.Entities.Matricula> Matricula { get; set; }
        public AlunoView(Domain.Entities.Alunos entity) {
            Nome = entity.Nome.ToString();
            Email = entity.Email.ToString();
            Matricula = entity.Matriculas.ToList();
        }
    }
}
