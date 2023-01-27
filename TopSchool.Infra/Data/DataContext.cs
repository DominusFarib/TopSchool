using Microsoft.EntityFrameworkCore;
using TopSchool.Domain.Entities;
using TopSchool.Infra.Data.EntityMapping;

namespace TopSchool.Infra.Data;

public class DataContext : DbContext
{
    public DbSet<Aluno> DbSetAluno { get; set; }
    public DbSet<Professor> DbSetProfessor { get; set; }
    public DbSet<Disciplina> DbSetDisciplina { get; set; }
    public DbSet<AlunoDisciplinas> DbSetAlunoDisciplina { get; set; }
    public DbSet<DisciplinaProfessores> DbSetDisciplinaProfessor { get; set; }

    public DataContext(DbContextOptions<DataContext> pOptions) : base(pOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        //foreach (var entity in modelBuilder.Model.GetEntityTypes())
        //{
        //    var v = entity.Name;
        //    var c = entity.ClrType.Name;

        //    foreach (var column in entity.GetProperties().Where(col => col.ClrType == typeof(int)))
        //    {
        //        if (column.Name == "Id")
        //        {
        //            entity.SetPrimaryKey(column);
        //        }
        //    }
        //}


        #region CONFIGS TABLES MAP

        modelBuilder.Entity<Aluno>(new AlunoConfig().Configure);
        modelBuilder.Entity<Professor>(new ProfessorConfig().Configure);
        modelBuilder.Entity<Disciplina>(new DisciplinaConfig().Configure);
        modelBuilder.Entity<AlunoDisciplinas>(new AlunoDisciplinasConfig().Configure);
        modelBuilder.Entity<DisciplinaProfessores>(new DisciplinaProfessoresConfig().Configure);
        //modelBuilder.Entity<DisciplinaProfessores>().Ignore(c => c.AlunosDaDisciplina);

        //modelBuilder.Entity<Disciplina>().Ignore(c => c.ProfessoresDaDisciplinas);

        //RETURN DEFAULT VALUE
        modelBuilder.Entity<Aluno>().HasData(
            new Aluno
            {
                Id = 100,
                Nome = "Admin",
                NrMatricula = 100,
                DtCreate = DateTime.Now
            });

        #endregion

        //// Muitos para muitos
        //modelBuilder.Entity<AlunoDisciplinas>().HasKey(AD => new { AD.AlunoId, AD.DisciplinaProfessoresId });
        //modelBuilder.Entity<DisciplinaProfessores>().HasKey(DP => new { DP.ProfessorId, DP.DisciplinaId });


    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DtCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DtCreate").CurrentValue = DateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Property("DtCreate").IsModified = false;
            }

        }

        return base.SaveChanges();

    }
}