using SGBIMFurnas.Dtos.FaseDto;

namespace SGBIMFurnas.Dtos.TransicaoDto;

public class FaseTransicaoAnteriorReadDto
{
    public FaseReadDto FaseAnterior { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}
