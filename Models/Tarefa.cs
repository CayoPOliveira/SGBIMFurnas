using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGBIMFurnas.Models;

public class Tarefa
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public int Priority { get; set; } = 1;

    [Required]
    public int Status { get; set; } = 1;

    public DateTime? FinishDate { get; set; } = null;

    public DateTime? DeadlineDate { get; set; } = null;

    [Required]
    public bool Valid { get; set; } = true;

    // Usuário que criou a atividade
    //[Required]
    //public int UsuarioId { get; set; }
    //public virtual Usuario Usuario { get; set; }

    // Usuário designado como responsável
    //[Required]
    //public int UsuarioResponsavelId { get; set; }
    //public virtual Usuario UsuarioResponsavel { get; set; }

    [Required]
    public int FaseId { get; set; }
    [ForeignKey("FaseId")]
    public virtual Fase Fase { get; set; }

    public int? TarefaAnteriorId { get; set; }
    [ForeignKey("TarefaAnteriorId")]
    public virtual Tarefa? TarefaAnterior { get; set; }
    public virtual Tarefa? TarefaSeguinte { get; set; }
}
