namespace TopSchool.Domain.Models;
public abstract class ModelBase
{
    public int Id { get; set; }
    public DateTime? DtCreate { get; set; }
    public DateTime? DtUpdate { get; set; }

}
