using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Professor.View.Simple {
    public class ProfessorSimpleListViewModel {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public ProfessorSimpleListViewModel(Domain.Entities.Professor entity) {
            Id = entity.Id;
            Nome = entity.Professor_Nome.ToString();
            Email = entity.Professor_Email.ToString();
        }
    }
}
