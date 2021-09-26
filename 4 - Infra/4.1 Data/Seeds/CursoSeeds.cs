using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Seeds
{
    public static class CursoSeeds
    {
        public static void Cursos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>().HasData(
                new Curso("Inglês", Domain.Enum.EDificuldade.Iniciante, 70),
                new Curso("Espanhol", Domain.Enum.EDificuldade.Iniciante, 70),
                new Curso("Italiano", Domain.Enum.EDificuldade.Iniciante, 80),
                new Curso("Alemão", Domain.Enum.EDificuldade.Iniciante, 90),

                new Curso("Inglês", Domain.Enum.EDificuldade.Intermediario, 110),
                new Curso("Espanhol", Domain.Enum.EDificuldade.Intermediario, 110),
                new Curso("Italiano", Domain.Enum.EDificuldade.Intermediario, 150),
                new Curso("Alemão", Domain.Enum.EDificuldade.Intermediario, 180),

                new Curso("Inglês", Domain.Enum.EDificuldade.Avancado, 150),
                new Curso("Espanhol", Domain.Enum.EDificuldade.Avancado, 190),
                new Curso("Italiano", Domain.Enum.EDificuldade.Avancado, 220),
                new Curso("Alemão", Domain.Enum.EDificuldade.Avancado, 280)
            );

        }
    }
}
