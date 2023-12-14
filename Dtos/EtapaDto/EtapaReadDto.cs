using System.ComponentModel.DataAnnotations;

namespace SGBIMFurnas.Dtos.EtapaDto;

public class EtapaReadDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}
