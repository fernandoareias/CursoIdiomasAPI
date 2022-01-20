using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infra.Data.Mapping
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {


            builder.ToTable("Professor");
            builder.HasKey(p => p.Id);

            builder.OwnsOne(x => x.Email)
                .Property(e => e.Address)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(80)
                .IsRequired();

            builder.OwnsOne(x => x.Nome)
                .Property(x => x.FirstName)
                .HasColumnName("Nome")
                .HasColumnType("nvarchar")
                .HasMaxLength(80)
                .IsRequired();

            builder.OwnsOne(x => x.Nome)
                .Property(x => x.LastName)
                .HasColumnName("Sobrenome")
                .HasColumnType("nvarchar")
                .HasMaxLength(80)
                .IsRequired();


            builder.Property(p => p.Salario)
                .HasColumnName("Salario")
                .HasColumnType("decimal")
                .HasPrecision(5, 2)
                .IsRequired();

            builder.HasOne(x => x.Curso).WithMany(x => x.Professores);

        }
    }
}
