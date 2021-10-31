using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Aluno.DTOs {
    public class AlunoCreateDTO {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public Domain.Aluno.DTOs.AlunoCreateDTO ToDomain() {
            return new CursoIdiomas.Domain.Aluno.DTOs.AlunoCreateDTO() {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email
            };
        }
    }
}
