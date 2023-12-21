using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGBIMFurnas.Models;

public class Fase
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MaxLength]
    public string? Description { get; set; }

    [Required]
    public bool Valid { get; set; } = true;

    [Required]
    public int EtapaId { get; set; }
    [ForeignKey("EtapaId")]
    public virtual Etapa Etapa { get; set; }

    public virtual ICollection<FaseTransicao>  FasesAnteriores { get; set; }
    public virtual ICollection<FaseTransicao> FasesSeguintes { get; set; }

    public virtual ICollection<Tarefa> Tarefas { get; set; }
}
