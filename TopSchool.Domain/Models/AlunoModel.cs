namespace TopSchool.Domain.Models;

public class AlunoModel: AssociadoBase
{
    public int Idade { get; set; }
    public IEnumerable<AlunoDisciplinasModel> AlunoDisciplinas { get; set; }

}
