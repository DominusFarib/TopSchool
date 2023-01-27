namespace TopSchool.Domain.Models;

public class ProfessorModel : AssociadoBase
{
    public IEnumerable<DisciplinaProfessoresModel> DisciplinasDoProfessor { get; set; }
}