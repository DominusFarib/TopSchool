namespace TopSchool.Domain.Models;

public class ProfessorModel : AssociadoBase
{
    public IEnumerable<DisciplinaModel> Disciplinas { get; set; }
}