using SGBIMFurnas.Dtos.FaseDto;

namespace SGBIMFurnas.Dtos.TransicaoDto;

public class FaseTransicaoReadDto
{
    public FaseReadDto FaseAnterior { get; set; }
    public FaseReadDto FaseSeguinte { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}
