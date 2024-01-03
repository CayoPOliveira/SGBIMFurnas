using System.ComponentModel.DataAnnotations;

namespace SGBIMFurnas.Dtos.TarefaDto;

public class TarefaUpdateDto
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public int Priority { get; set; }

    [Required]
    public int Status { get; set; }
    public DateTime FinishDate { get; set; }
    public DateTime DeadlineDate { get; set; }

}
