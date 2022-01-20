using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CursoIdiomas.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Boletim> Boletim { get; set; }
        public DbSet<Mensalidade> Mensalidade { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Curso>(new CursoMap().Configure);
            modelBuilder.Entity<Professor>(new ProfessorMap().Configure);
            modelBuilder.Entity<Turma>(new TurmaMap().Configure);
            modelBuilder.Entity<Alunos>(new AlunoMap().Configure);
            modelBuilder.Entity<Matricula>(new MatriculaMap().Configure);
            modelBuilder.Entity<Boletim>(new BoletimMap().Configure);
            modelBuilder.Entity<Mensalidade>(new MensalidadesMap().Configure);
        }
    }
}
