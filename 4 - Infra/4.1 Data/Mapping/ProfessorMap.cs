using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infra.Data.Mapping {
    public class ProfessorMap : IEntityTypeConfiguration<Professor> {
        public void Configure(EntityTypeBuilder<Professor> builder) {


            builder.ToTable("Professor");
            builder.HasKey(p => p.Id);
            builder.OwnsOne(x => x.Professor_Email);
            
            builder.Ignore(x => x.Notifications);
            builder.OwnsOne(x => x.Professor_Nome).Property(x => x.FirstName).HasColumnName("Nome").HasColumnType("nvarchar(80)");
            builder.OwnsOne(x => x.Professor_Nome).Property(x => x.LastName).HasColumnName("Sobrenome").HasColumnType("nvarchar(80)");
            builder.Property(p => p.Salario);

            builder.HasOne(x => x.Curso).WithMany(x => x.Professores);

        }
    }
}
