using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Professor.DTO {
    public class ProfessorDTO {
        public ProfessorDTO() {

        }

        public ProfessorDTO(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public CursoIdiomas.Domain.Professor.DTO.ProfessorDTO ToDomain() {
            return new CursoIdiomas.Domain.Professor.DTO.ProfessorDTO {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email
            };
        }
            

    }
}
