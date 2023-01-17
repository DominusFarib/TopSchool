using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopSchool.Domain.Entities;

[Table("TB_DISCIPLINA")]
public class Disciplina : EntityBase
{

    [Required]
    [StringLength(100)]
    [MaxLength(100)]
    [DataType(DataType.Text)]
    public string Titulo { get; set; }
    public Disciplina(string titulo)
    {
        Titulo = titulo;
    }
    public IEnumerable<DisciplinaProfessores> ProfessoresDaDisciplinas { get; set; }
}

