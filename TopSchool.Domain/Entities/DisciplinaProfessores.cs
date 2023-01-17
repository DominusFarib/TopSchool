using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopSchool.Domain.Entities;
[Table("TB_DISCIPLINA_PROFESSORES")]
public class DisciplinaProfessores : EntityBase
{
    [Required]
    public int ProfessorId { get; set; }

    [Required]
    public int DisciplinaId { get; set; }


    [ForeignKey("ProfessorId")]
    public Professor Professor { get; set; }


    [ForeignKey("DisciplinaId")]
    public Disciplina Disciplina { get; set; }

    public IEnumerable<AlunoDisciplinas> AlunosDaDisciplina { get; set; }

    public DisciplinaProfessores() { }
    public DisciplinaProfessores(int professorId, int disciplinaId)
    {
        ProfessorId = professorId;
        DisciplinaId = disciplinaId;
    }

    public DisciplinaProfessores(Professor professor, Disciplina disciplina)
    {
        Professor = professor;
        Disciplina = disciplina;
    }
}
