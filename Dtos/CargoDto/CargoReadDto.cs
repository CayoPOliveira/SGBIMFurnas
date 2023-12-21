namespace SGBIMFurnas.Dtos.CargoDto;

public class CargoReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Permissions { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}
