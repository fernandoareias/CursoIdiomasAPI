using CursoIdiomasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoIdiomasAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        //public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Professores> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
    }
}