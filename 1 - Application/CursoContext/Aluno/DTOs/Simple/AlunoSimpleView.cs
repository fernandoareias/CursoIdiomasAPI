using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Aluno.DTOs.Simple {
    public class AlunoSimpleView {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public AlunoSimpleView(Domain.Entities.Alunos entity) {
            Id = entity.Id;
            Nome = entity.Nome.ToString();
            Email = entity.Email.ToString();
        }
    }
}
