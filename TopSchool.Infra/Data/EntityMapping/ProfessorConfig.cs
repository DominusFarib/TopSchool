using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopSchool.Domain.Entities;

namespace TopSchool.Infra.Data.EntityMapping;

public class ProfessorConfig : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        // TB_PROFESSOR
        builder.ToTable("TB_PROFESSOR");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Nome).IsRequired().HasColumnType("varchar(100)");
        builder.Property(e => e.NrMatricula).IsRequired(false).HasColumnType("int");

        builder.Property(e => e.DtNascimento).IsRequired().HasColumnType("datetime");
        builder.Property(e => e.DtCreate).IsRequired(false).HasColumnType("datetime");
        builder.Property(e => e.DtUpdate).IsRequired(false).HasColumnType("datetime");
    }
}
