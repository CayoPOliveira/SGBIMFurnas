using SGBIMFurnas.Dtos.FaseDto;

namespace SGBIMFurnas.Dtos.TarefaDto;

public class TarefaSeguinteReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public int Status { get; set; }
    public DateTime FinishDate { get; set; }
    public DateTime DeadlineDate { get; set; }
    public FaseReadDto Fase { get; set; }
    public TarefaSeguinteReadDto? TarefaSeguinte { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
}
