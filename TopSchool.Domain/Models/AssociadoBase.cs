namespace TopSchool.Domain.Models;

public abstract class AssociadoBase : ModelBase
{
    public string Nome { get; set; }
    public int? NrMatricula { get; set; }
    public DateTime DtNascimento { get; set; }
}
