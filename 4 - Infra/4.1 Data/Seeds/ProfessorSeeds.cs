using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Cursos.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoIdiomas.Domain.Professor;
using CursoIdiomas.Domain.ValueObjects;

namespace CursoIdiomas.Infra.Data.Seeds {
    public static class ProfessorSeeds {
        public static Nome nome1 = new Nome("bobson", "bobi");
        public static Email email1 = new Email("bob@bobson.com.br");

        public static void Professor(ModelBuilder modelBuilder) {
          
            modelBuilder.Entity<Professor>().HasData(
                new Professor(new Guid("80d71825-3434-4503-902e-28fb2c5323f8"), nome1, email1)
                
               
            );

        }
    }
}
