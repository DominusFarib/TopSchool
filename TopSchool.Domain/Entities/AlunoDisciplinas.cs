using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopSchool.Domain.Entities;

[Table("TB_ALUNO_DISCIPLINAS")]
public class AlunoDisciplinas : EntityBase
{

    [Required]
    public int AlunoId { get; set; }
    
    [Required]
    public int DisciplinaProfessoresId { get; set; }
    
    [ForeignKey("AlunoId")]
    public Aluno Aluno { get; set; }

    [ForeignKey("DisciplinaProfessoresId")]
    public DisciplinaProfessores ProfessorDaDisciplina { get; set; }

    public AlunoDisciplinas() { }
    public AlunoDisciplinas(int alunoId, int disciplinaProfessorId)
    {
        AlunoId = alunoId;
        DisciplinaProfessoresId = disciplinaProfessorId;
    }

    public AlunoDisciplinas(int alunoId, int disciplinaId, Aluno aluno, DisciplinaProfessores disciplina)
    {
        AlunoId = alunoId;
        DisciplinaProfessoresId = disciplinaId;
        Aluno = aluno;
        ProfessorDaDisciplina = disciplina;
    }
}
