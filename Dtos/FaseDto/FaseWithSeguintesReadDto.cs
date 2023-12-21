using SGBIMFurnas.Dtos.EtapaDto;
using SGBIMFurnas.Dtos.TransicaoDto;

namespace SGBIMFurnas.Dtos.FaseDto;

public class FaseWithSeguintesReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public EtapaReadDto Etapa { get; set; }
    public ICollection<FaseTransicaoSeguinteReadDto> FasesSeguintes { get; set; }
}
