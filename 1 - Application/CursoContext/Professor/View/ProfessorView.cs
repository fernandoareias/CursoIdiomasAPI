using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.CursoContext.Professor.View {
    public class ProfessorView {
        public ProfessorView() {

        }
        public ProfessorView(string nome, string email) {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; set; }
        public string Email { get; set; }

        public static ProfessorView Mapping(CursoIdiomas.Domain.Professor.Professor model) {
            //if (model== null) {
            //    return null;
            //}

            return new ProfessorView {
                Nome = model.Professor_Nome.ToString(),
                Email = model.Professor_Email.ToString()
            };
        } public static IEnumerable<ProfessorView> Mapping(IEnumerable<CursoIdiomas.Domain.Professor.Professor> model) {
          
            var listaProfessores = new List<ProfessorView>();
            foreach(var professor in model) {
               var temp = new ProfessorView {
                   Nome = professor.Professor_Nome.ToString(),
                   Email = professor.Professor_Email.ToString()
               };
                listaProfessores.Add(temp);
            }
            return listaProfessores.ToArray();
        }
    }
}
