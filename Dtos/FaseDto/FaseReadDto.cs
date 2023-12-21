namespace SGBIMFurnas.Dtos.FaseDto;

public class FaseReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public int EtapaId { get; set; }
}
