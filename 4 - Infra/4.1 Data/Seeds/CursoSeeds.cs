using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Cursos.Enum;
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
                new Curso("Inglês", EDificuldade.Iniciante, 70),
                new Curso("Espanhol", EDificuldade.Iniciante, 70),
                new Curso("Italiano", EDificuldade.Iniciante, 80),
                new Curso("Alemão", EDificuldade.Iniciante, 90),

                new Curso("Inglês", EDificuldade.Intermediario, 110),
                new Curso("Espanhol", EDificuldade.Intermediario, 110),
                new Curso("Italiano", EDificuldade.Intermediario, 150),
                new Curso("Alemão", EDificuldade.Intermediario, 180),

                new Curso("Inglês", EDificuldade.Avancado, 150),
                new Curso("Espanhol", EDificuldade.Avancado, 190),
                new Curso("Italiano", EDificuldade.Avancado, 220),
                new Curso("Alemão", EDificuldade.Avancado, 280)
            );

        }
    }
}
