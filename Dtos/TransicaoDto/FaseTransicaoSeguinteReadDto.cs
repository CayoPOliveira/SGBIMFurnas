using SGBIMFurnas.Dtos.FaseDto;

namespace SGBIMFurnas.Dtos.TransicaoDto;

public class FaseTransicaoSeguinteReadDto
{
    public FaseWithSeguintesReadDto FaseSeguinte { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}
