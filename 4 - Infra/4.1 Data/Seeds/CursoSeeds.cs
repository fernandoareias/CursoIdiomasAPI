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
            modelBuilder.Entity<Curso>().HasData(
                new Curso(new Guid("6734550d-960a-4267-8ab2-bdfeca55af39"), "Inglês", EDificuldade.Iniciante, 70),
                new Curso(new Guid("7e939021-06c7-4372-b933-3bfde5ed889f"), "Espanhol", EDificuldade.Iniciante, 70),
                new Curso(new Guid("7a907cd0-8c35-4a6a-99a4-e536fa49964a"), "Italiano", EDificuldade.Iniciante, 80),
                new Curso(new Guid("716c6195-0c1d-4f35-93cf-6ed8176d2a88"), "Alemão", EDificuldade.Iniciante, 90),

                new Curso(new Guid("89818dd0-a82b-4c4d-ba77-723c1e7441ce"), "Inglês", EDificuldade.Intermediario, 110),
                new Curso(new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), "Espanhol", EDificuldade.Intermediario, 110),
                new Curso(new Guid("b37e29ed-f758-49e3-9fa8-02eb6547e17c"), "Italiano", EDificuldade.Intermediario, 150),
                new Curso(new Guid("fdfc1363-0ac1-4c1e-b1e1-ab81b58e9db0"), "Alemão", EDificuldade.Intermediario, 180),

                new Curso(new Guid("bce8c282-07c8-48b8-881b-c85a539abf7e"), "Inglês", EDificuldade.Avancado, 150),
                new Curso(new Guid("cba9b402-89d3-45b7-bdfc-c2a8b34ca4c3"), "Espanhol", EDificuldade.Avancado, 190),
                new Curso(new Guid("dee8ca19-25ed-4e0f-b49e-ec29a8365f55"), "Italiano", EDificuldade.Avancado, 220),
                new Curso(new Guid("782ffb30-bfff-43c1-b1ab-a4b6c9ebfc16"), "Alemão", EDificuldade.Avancado, 280)
            );

        }
    }
}
