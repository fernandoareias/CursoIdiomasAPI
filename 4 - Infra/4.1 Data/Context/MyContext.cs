using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Professor;
using CursoIdiomas.Domain.ValueObjects;
using CursoIdiomas.Infra.Data.Mapping;
using CursoIdiomas.Infra.Data.Seeds;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Turma> Curso { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Notification>().HasNoKey();

            modelBuilder.Entity<Curso>(new CursoMap().Configure);
            modelBuilder.Entity<Turma>(new TurmaMap().Configure);
            modelBuilder.Entity<Professor>(new ProfessorMap().Configure);
            modelBuilder.Entity<Alunos>(new AlunoMap().Configure);
            modelBuilder.Entity<Matricula>(new MatriculaMap().Configure);
            modelBuilder.Entity<Boletim>(new BoletimMap().Configure);
            modelBuilder.Entity<Mensalidade>(new MensalidadesMap().Configure);
            CursoSeeds.Cursos(modelBuilder);
        }
    }
}
