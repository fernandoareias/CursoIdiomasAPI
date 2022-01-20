using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infra.Data.Mapping
{
    public class AlunoMap : IEntityTypeConfiguration<Alunos>
    {
        public void Configure(EntityTypeBuilder<Alunos> builder)
        {


            builder.ToTable("Aluno");
            builder.HasKey(p => p.Id);
            builder.OwnsOne(x => x.Nome)
                .Property(x => x.FirstName)
                .HasColumnName("Nome")
                .HasColumnType("nvarchar")
                .HasMaxLength(80)
                .IsRequired();

            builder.OwnsOne(x => x.Nome)
                .Property(x => x.LastName)
                .HasColumnName("Sobrenome")
                .HasMaxLength(80)
                .IsRequired();

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Address)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(120)
                .IsRequired();

            builder.HasMany(x => x.Matriculas).WithOne(m => m.Aluno);
        }
    }
}
