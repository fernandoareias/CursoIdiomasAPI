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
                new Turma {
                    DataInicio = DateTime.Now,
                    DataFim = null,
                    CursoId = new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"),
                    ProfessorId = new Guid("80d71825-3434-4503-902e-28fb2c5323f8")
                }
            );

        }
    }
}
