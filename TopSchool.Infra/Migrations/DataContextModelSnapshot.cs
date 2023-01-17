﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopSchool.Infra.Data;

#nullable disable

namespace TopSchool.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("TopSchool.Domain.Entities.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DtCreate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DtUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("NrMatricula")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_ALUNO", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 100,
                            DtCreate = new DateTime(2023, 1, 16, 21, 8, 50, 418, DateTimeKind.Local).AddTicks(3982),
                            DtNascimento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Admin",
                            NrMatricula = 100
                        });
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.AlunoDisciplinas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaProfessoresId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DtCreate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DtUpdate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaProfessoresId");

                    b.ToTable("TB_ALUNO_DISCIPLINAS", (string)null);
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DtCreate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DtUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("TB_DISCIPLINA", (string)null);
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.DisciplinaProfessores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DtCreate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DtUpdate")
                        .HasColumnType("datetime");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("TB_DISCIPLINA_PROFESSORES", (string)null);
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DtCreate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DtUpdate")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("NrMatricula")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_PROFESSOR", (string)null);
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.AlunoDisciplinas", b =>
                {
                    b.HasOne("TopSchool.Domain.Entities.Aluno", "Aluno")
                        .WithMany("AlunoDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopSchool.Domain.Entities.DisciplinaProfessores", "ProfessorDaDisciplina")
                        .WithMany("AlunosDaDisciplina")
                        .HasForeignKey("DisciplinaProfessoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("ProfessorDaDisciplina");
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.DisciplinaProfessores", b =>
                {
                    b.HasOne("TopSchool.Domain.Entities.Disciplina", "Disciplina")
                        .WithMany("ProfessoresDaDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopSchool.Domain.Entities.Professor", "Professor")
                        .WithMany("DisciplinasDoProfessor")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.Aluno", b =>
                {
                    b.Navigation("AlunoDisciplinas");
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.Disciplina", b =>
                {
                    b.Navigation("ProfessoresDaDisciplinas");
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.DisciplinaProfessores", b =>
                {
                    b.Navigation("AlunosDaDisciplina");
                });

            modelBuilder.Entity("TopSchool.Domain.Entities.Professor", b =>
                {
                    b.Navigation("DisciplinasDoProfessor");
                });
#pragma warning restore 612, 618
        }
    }
}
