using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopSchool.Domain.Entities;

namespace TopSchool.Infra.Data.EntityMapping;

public class DisciplinaConfig : IEntityTypeConfiguration<Disciplina>
{
    public void Configure(EntityTypeBuilder<Disciplina> builder)
    {
        // TB_PROFESSOR
        builder.ToTable("TB_DISCIPLINA");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Titulo).IsRequired().HasColumnType("varchar(80)");

        builder.Property(e => e.DtCreate).IsRequired(false).HasColumnType("datetime");
        builder.Property(e => e.DtUpdate).IsRequired(false).HasColumnType("datetime");
    }
}
