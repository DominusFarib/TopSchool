using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopSchool.Infra.Migrations
{
    public partial class DbTopSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALUNO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DtUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtCreate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NrMatricula = table.Column<int>(type: "int", nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_DISCIPLINA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "varchar(80)", maxLength: 100, nullable: false),
                    DtUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtCreate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISCIPLINA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROFESSOR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DtUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtCreate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NrMatricula = table.Column<int>(type: "int", nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROFESSOR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_DISCIPLINA_PROFESSORES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    DtUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtCreate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISCIPLINA_PROFESSORES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_DISCIPLINA_PROFESSORES_TB_DISCIPLINA_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "TB_DISCIPLINA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_DISCIPLINA_PROFESSORES_TB_PROFESSOR_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "TB_PROFESSOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALUNO_DISCIPLINAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaProfessoresId = table.Column<int>(type: "int", nullable: false),
                    DtUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtCreate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNO_DISCIPLINAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ALUNO_DISCIPLINAS_TB_ALUNO_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "TB_ALUNO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ALUNO_DISCIPLINAS_TB_DISCIPLINA_PROFESSORES_DisciplinaProfessoresId",
                        column: x => x.DisciplinaProfessoresId,
                        principalTable: "TB_DISCIPLINA_PROFESSORES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_ALUNO",
                columns: new[] { "Id", "DtCreate", "DtNascimento", "DtUpdate", "Nome", "NrMatricula" },
                values: new object[] { 100, new DateTime(2023, 1, 16, 21, 8, 50, 418, DateTimeKind.Local).AddTicks(3982), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", 100 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNO_DISCIPLINAS_AlunoId",
                table: "TB_ALUNO_DISCIPLINAS",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNO_DISCIPLINAS_DisciplinaProfessoresId",
                table: "TB_ALUNO_DISCIPLINAS",
                column: "DisciplinaProfessoresId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DISCIPLINA_PROFESSORES_DisciplinaId",
                table: "TB_DISCIPLINA_PROFESSORES",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DISCIPLINA_PROFESSORES_ProfessorId",
                table: "TB_DISCIPLINA_PROFESSORES",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALUNO_DISCIPLINAS");

            migrationBuilder.DropTable(
                name: "TB_ALUNO");

            migrationBuilder.DropTable(
                name: "TB_DISCIPLINA_PROFESSORES");

            migrationBuilder.DropTable(
                name: "TB_DISCIPLINA");

            migrationBuilder.DropTable(
                name: "TB_PROFESSOR");
        }
    }
}
