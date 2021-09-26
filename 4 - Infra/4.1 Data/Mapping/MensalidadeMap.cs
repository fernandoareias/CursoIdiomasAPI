using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Mapping {
    public class MensalidadesMap : IEntityTypeConfiguration<Turma> {
        public void Configure(EntityTypeBuilder<Turma> builder) {


            builder.ToTable("Mensalidade");
            builder.HasKey(p => p.Id);
            builder.Ignore(x => x.Notifications);
            builder.Property(x => x.Vencimento);
            builder.Property(x => x.Valor);

            builder.HasOne(x => x.Matricula).WithMany(y => y.Mensalidades);
        }
    }
}
