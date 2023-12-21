using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGBIMFurnas.Models;

public class FaseTransicao
{
    [Required]
    public int FaseAnteriorId { get; set; }
    [ForeignKey("FaseAnteriorId")]
    public virtual Fase FaseAnterior { get; set; }

    [Required]
    public int FaseSeguinteId { get; set; }
    [ForeignKey("FaseSeguinteId")]
    public virtual Fase FaseSeguinte { get; set; }
}
