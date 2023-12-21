using SGBIMFurnas.Dtos.FaseDto;

namespace SGBIMFurnas.Dtos.EtapaDto;

public class EtapaWithFasesReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public ICollection<FaseReadDto> Fases { get; set; }
}
