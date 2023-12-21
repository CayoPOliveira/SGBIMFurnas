using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SGBIMFurnas.Data;
using SGBIMFurnas.Dtos.CargoDto;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Controllers;

[ApiController]
[Route("[controller]")]
public class CargoController : ControllerBase
{
    private DatabaseContext _context;
    private IMapper _mapper;

    public CargoController(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CriaCargo([FromBody] CargoCreateDto cargoDto)
    {
        Cargo cargo = _mapper.Map<Cargo>(cargoDto);
        Console.WriteLine(cargo.Id);
        _context.Cargos.Add(cargo);
        _context.SaveChanges();
        Console.WriteLine(cargo.Id);
        return CreatedAtAction(nameof(RecuperaCargoComId), new { id = cargo.Id }, cargo);
    }

    [HttpGet]
    public IEnumerable<CargoReadDto> RecuperaCargos([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<CargoReadDto>>(_context.Cargos.Where(cargo => cargo.Valid).Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCargoComId(int id)
    {
        Cargo cargoEncontrado = _context.Cargos.FirstOrDefault(cargo => cargo.Id == id && cargo.Valid);
        return cargoEncontrado == null ? NotFound() : Ok(_mapper.Map<CargoReadDto>(cargoEncontrado));
    }

    [HttpGet("deleted")]
    public IEnumerable<CargoReadDto> RecuperaCargosQueForamDeletados([FromQuery] int skip = 0, [FromQuery] int take = 3)
    {
        return _mapper.Map<List<CargoReadDto>>(_context.Cargos.Where(cargo => !cargo.Valid).Skip(skip).Take(take));
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCargo(int id, [FromBody] CargoUpdateDto cargoDto)
    {
        var cargo = _context.Cargos.FirstOrDefault(cargo => cargo.Id == id && cargo.Valid);
        if (cargo == null) return NotFound();

        _mapper.Map(cargoDto, cargo);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaCargoParcial(int id, JsonPatchDocument<CargoUpdateDto> patch)
    {
        var cargo = _context.Cargos.FirstOrDefault(cargo => cargo.Id == id && cargo.Valid);
        if (cargo == null) return NotFound();

        var cargoAtualizar = _mapper.Map<CargoUpdateDto>(cargo);
        patch.ApplyTo(cargoAtualizar, ModelState);
        if (!TryValidateModel(cargoAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(cargoAtualizar, cargo);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCargo(int id)
    {
        var cargo = _context.Cargos.FirstOrDefault(cargo => cargo.Id == id && cargo.Valid);
        if (cargo == null) return NotFound();

        cargo.Valid = false;
        _context.Update(cargo);
        _context.SaveChanges();
        return NoContent();
    }
}
