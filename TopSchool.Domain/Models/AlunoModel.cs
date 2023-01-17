namespace TopSchool.Domain.Models;

public class AlunoModel: AssociadoBase
{
    public IEnumerable<AlunoDisciplinasModel> AlunoDisciplinas { get; set; }

}
