using System.ComponentModel.DataAnnotations.Schema;

namespace TopSchool.Domain.Entities;

[Table("TB_ALUNO")]
public class Aluno : AssociadoBase
{

    public IEnumerable<AlunoDisciplinas> AlunoDisciplinas { get; set; }

}
