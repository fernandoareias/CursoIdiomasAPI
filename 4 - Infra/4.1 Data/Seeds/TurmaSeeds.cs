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
    public static class TurmaSeeds {
        public static void Turma(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Turma>().HasData(
                new Turma(1, 1)
            );

        }
    }
}
