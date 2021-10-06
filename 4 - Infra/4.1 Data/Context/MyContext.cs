using CursoIdiomas.Domain.Cursos.Curso;
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
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<CursoIdiomas.Domain.Entities.Professor> Professors { get; set; }
        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Boletim> Boletim { get; set; }
        public DbSet<Cobranca> Mensalidade { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Notification>().HasNoKey();
     
            modelBuilder.Entity<Curso>(new CursoMap().Configure);
           
            modelBuilder.Entity<CursoIdiomas.Domain.Entities.Professor>(new ProfessorMap().Configure);
            
          
          modelBuilder.Entity<Turma>(new TurmaMap().Configure);
            modelBuilder.Entity<Alunos>(new AlunoMap().Configure);
            modelBuilder.Entity<Matricula>(new MatriculaMap().Configure);
            modelBuilder.Entity<Boletim>(new BoletimMap().Configure);
           modelBuilder.Entity<Cobranca>(new MensalidadesMap().Configure);
           // CursoSeeds.Cursos(modelBuilder);

         //  ProfessorSeeds.Professor(modelBuilder);
           //TurmaSeeds.Turma(modelBuilder);

        
        }
    }
}
