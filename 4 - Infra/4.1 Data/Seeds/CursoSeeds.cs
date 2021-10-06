using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Cursos.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoIdiomas.Domain.Cursos.Curso;

namespace CursoIdiomas.Infra.Data.Seeds
{
    public static class CursoSeeds
    {
        public static void Cursos(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Curso>().HasData(
                new Curso("Inglês", EDificuldade.Iniciante, 280, DateTime.Now.AddDays(2))
             
            );*/

        }
    }
}
