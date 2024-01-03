using SGBIMFurnas.Models;
using System.ComponentModel.DataAnnotations;

namespace SGBIMFurnas.Dtos.TarefaDto;

public class TarefaCreateDto
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public int Priority { get; set; }

    [Required]
    public int Status { get; set; }

    public DateTime? FinishDate { get; set; }

    public DateTime? DeadlineDate { get; set; }

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

    public int? TarefaAnteriorId { get; set; } = null;
}
