using System.ComponentModel.DataAnnotations.Schema;

namespace TopSchool.Domain.Entities;
[Table("TB_PROFESSOR")]
public class Professor : AssociadoBase
{
    public IEnumerable<DisciplinaProfessores> DisciplinasDoProfessor { get; set; }
}