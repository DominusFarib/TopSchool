namespace TopSchool.Domain.Models;
public class DisciplinaModel : ModelBase
{
    public string Titulo { get; set; }
    public IEnumerable<DisciplinaProfessoresModel> ProfessoresDaDisciplinas { get; set; }

}
