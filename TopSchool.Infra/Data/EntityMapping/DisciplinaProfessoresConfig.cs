using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopSchool.Domain.Entities;

namespace TopSchool.Infra.Data.EntityMapping;

public class DisciplinaProfessoresConfig : IEntityTypeConfiguration<DisciplinaProfessores>
{
    public void Configure(EntityTypeBuilder<DisciplinaProfessores> builder)
    {
        builder.ToTable("TB_DISCIPLINA_PROFESSORES");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.DtCreate).IsRequired(false).HasColumnType("datetime");
        builder.Property(e => e.DtUpdate).IsRequired(false).HasColumnType("datetime");

        builder.Property(e => e.ProfessorId).IsRequired().HasColumnType("int");
        builder.Property(e => e.DisciplinaId).IsRequired().HasColumnType("int");

        builder.HasOne(e => e.Professor).WithMany(p=>p.DisciplinasDoProfessor).HasForeignKey(e => e.ProfessorId);

        builder.HasOne(e => e.Disciplina).WithMany(d => d.ProfessoresDaDisciplinas).HasForeignKey(e => e.DisciplinaId);
    }
}
