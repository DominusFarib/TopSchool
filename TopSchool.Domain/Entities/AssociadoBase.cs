using System.ComponentModel.DataAnnotations;


namespace TopSchool.Domain.Entities;

public abstract class AssociadoBase : EntityBase
{
	[Required]
	[StringLength(100)]
	[MaxLength(100)]
	[DataType(DataType.Text)]
	public string Nome { get; set; }
	
    public int? NrMatricula { get; set; }
	
    public DateTime DtNascimento { get; set; }
}
