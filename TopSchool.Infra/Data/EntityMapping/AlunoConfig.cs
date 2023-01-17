using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopSchool.Domain.Entities;

namespace TopSchool.Infra.Data.EntityMapping;

public class AlunoConfig : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        // TB_ALUNO
        builder.ToTable("TB_ALUNO");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Nome).IsRequired().HasColumnType("varchar(100)");
        builder.Property(e => e.NrMatricula).IsRequired(false).HasColumnType("int");

        builder.Property(e => e.DtNascimento).IsRequired().HasColumnType("datetime");
        builder.Property(e => e.DtCreate).IsRequired(false).HasColumnType("datetime");
        builder.Property(e => e.DtUpdate).IsRequired(false).HasColumnType("datetime");
    }
}
