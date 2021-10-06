using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Professor.View {
    public class ProfessorView {
        public ProfessorView() {    

        }
        public ProfessorView(long id, string nome, string email) {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static ProfessorView Mapping(CursoIdiomas.Domain.Entities.Professor model) {
        
            return new ProfessorView {
                Id = model.Id,
                Nome = model.Professor_Nome.ToString(),
                Email = model.Professor_Email.ToString()
            };
        } public static IEnumerable<ProfessorView> Mapping(IEnumerable<CursoIdiomas.Domain.Entities.Professor> model) {
          
            var listaProfessores = new List<ProfessorView>();
            foreach(var professor in model) {
                var temp = new ProfessorView {
                    Id = professor.Id,
                   Nome = professor.Professor_Nome.ToString(),
                   Email = professor.Professor_Email.ToString()
               };
                listaProfessores.Add(temp);
            }
            return listaProfessores.ToArray();
        }
    }
}
