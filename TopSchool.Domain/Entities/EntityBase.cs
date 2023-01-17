using System.ComponentModel.DataAnnotations;
namespace TopSchool.Domain.Entities;

public abstract class EntityBase
{        
	[Key]
	public int Id { get; set; }
	
	public DateTime? DtUpdate { get; set; }
	
	private DateTime? _DtCreate;
	
	public DateTime? DtCreate
	{
		get { return _DtCreate; }
		set { _DtCreate = (value == null ? DateTime.UtcNow : value); }
	}

	public override string? ToString()
	{
		return Id.ToString();
	}
}
