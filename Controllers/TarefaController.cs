using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SGBIMFurnas.Data;
using SGBIMFurnas.Dtos.EtapaDto;
using SGBIMFurnas.Dtos.FaseDto;
using SGBIMFurnas.Dtos.TarefaDto;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefaController : ControllerBase
{
    private DatabaseContext _context;
    private IMapper _mapper;

    public TarefaController(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CriaTarefa([FromBody] TarefaCreateDto tarefaDto)
    {
        Tarefa tarefa = _mapper.Map<Tarefa>(tarefaDto);
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaTarefaComId), new { id = tarefa.Id }, tarefa);
    }

    [HttpGet]
    public IEnumerable<TarefaReadDto> RecuperaTarefas([FromQuery] int skip = 0, [FromQuery] int take = 15)
    {
        return _mapper.Map<List<TarefaReadDto>>(_context.Tarefas.Where(tarefa => tarefa.Valid).Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaTarefaComId(int id)
    {
        Tarefa tarefaEncontrada = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id && tarefa.Valid);
        return tarefaEncontrada == null ? NotFound() : Ok(_mapper.Map<TarefaReadDto>(tarefaEncontrada));
    }

    [HttpGet("{id}/Anteriores")]
    public IActionResult RecuperaTarefaEAnterioresComId(int id)
    {
        Tarefa tarefaEncontrada = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id && tarefa.Valid);
        return tarefaEncontrada == null ? NotFound() : Ok(_mapper.Map<TarefaAnteriorReadDto>(tarefaEncontrada));
    }

    [HttpGet("{id}/Seguintes")]
    public IActionResult RecuperaTarefaESeguintesComId(int id)
    {
        Tarefa tarefaEncontrada = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id && tarefa.Valid);
        return tarefaEncontrada == null ? NotFound() : Ok(_mapper.Map<TarefaSeguinteReadDto>(tarefaEncontrada));
    }

    [HttpGet("Deleted")]
    public IEnumerable<TarefaReadDto> RecuperaTarefasQueForamDeletadas([FromQuery] int skip = 0, [FromQuery] int take = 3)
    {
        return _mapper.Map<List<TarefaReadDto>>(_context.Tarefas.Where(tarefa => !tarefa.Valid).Skip(skip).Take(take).ToList());
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaTarefa(int id, [FromBody] TarefaUpdateDto tarefaDto)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id && tarefa.Valid);
        if (tarefa == null) return NotFound();

        _mapper.Map(tarefaDto, tarefa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaTarefa(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id && tarefa.Valid);
        if (tarefa == null) return NotFound();

        tarefa.Valid = false;
        _context.Update(tarefa);
        _context.SaveChanges();
        return NoContent();
    }
}
