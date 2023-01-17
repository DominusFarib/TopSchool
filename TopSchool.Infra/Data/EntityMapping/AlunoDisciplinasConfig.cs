using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopSchool.Domain.Entities;

namespace TopSchool.Infra.Data.EntityMapping;

public class AlunoDisciplinasConfig : IEntityTypeConfiguration<AlunoDisciplinas>
{
    public void Configure(EntityTypeBuilder<AlunoDisciplinas> builder)
    {
        // TB_ALUNO
        builder.ToTable("TB_ALUNO_DISCIPLINAS");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.DtCreate).IsRequired(false).HasColumnType("datetime");
        builder.Property(e => e.DtUpdate).IsRequired(false).HasColumnType("datetime");

        builder.Property(e => e.AlunoId).IsRequired().HasColumnType("int");
        builder.Property(e => e.DisciplinaProfessoresId).IsRequired().HasColumnType("int");

        builder.HasOne(e => e.Aluno).WithMany(a => a.AlunoDisciplinas).HasForeignKey(e => e.AlunoId);

        builder.HasOne(e => e.ProfessorDaDisciplina).WithMany(p=>p.AlunosDaDisciplina).HasForeignKey(e => e.DisciplinaProfessoresId).OnDelete(DeleteBehavior.NoAction);

    }
}
