namespace TopSchool.Domain.Models;
public class DisciplinaProfessoresModel : ModelBase
{
    public int ProfessorId { get; set; }
    public int DisciplinaId { get; set; }
    public ProfessorModel Professor { get; set; }
    public DisciplinaModel Disciplina { get; set; }
    public IEnumerable<AlunoDisciplinasModel> AlunosDaDisciplina { get; set; }

    public DisciplinaProfessoresModel() { }
    public DisciplinaProfessoresModel(int professorId, int disciplinaId)
    {
        ProfessorId = professorId;
        DisciplinaId = disciplinaId;
    }

    public DisciplinaProfessoresModel(ProfessorModel professor, DisciplinaModel disciplina)
    {
        Professor = professor;
        Disciplina = disciplina;
    }
}
