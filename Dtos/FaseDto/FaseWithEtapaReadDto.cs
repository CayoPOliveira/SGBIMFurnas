using SGBIMFurnas.Dtos.EtapaDto;

namespace SGBIMFurnas.Dtos.FaseDto;

public class FaseWithEtapaReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public EtapaReadDto Etapa { get; set; }
}
