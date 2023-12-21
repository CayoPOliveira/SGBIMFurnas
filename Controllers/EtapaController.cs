using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using SGBIMFurnas.Data;
using SGBIMFurnas.Models;
using SGBIMFurnas.Dtos.EtapaDto;

namespace SGBIMFurnas.Controllers;

[ApiController]
[Route("[controller]")]
public class EtapaController : ControllerBase
{
    private DatabaseContext _context;
    private IMapper _mapper;

    public EtapaController(DatabaseContext context, IMapper mapper) { 
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CriaEtapa([FromBody] EtapaCreateDto etapaDto)
    {
        Etapa etapa = _mapper.Map<Etapa>(etapaDto);
        Console.WriteLine(etapa.Id);
        _context.Etapas.Add(etapa);
        _context.SaveChanges();
        Console.WriteLine(etapa.Id);
        return CreatedAtAction(nameof(RecuperaEtapaComId), new { id = etapa.Id }, etapa);
    }

    [HttpGet]
    public IEnumerable<EtapaWithFasesReadDto> RecuperaEtapas([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<EtapaWithFasesReadDto>>(_context.Etapas.Where(etapa => etapa.Valid).Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEtapaComId(int id)
    {
        Etapa etapaEncontrada = _context.Etapas.FirstOrDefault(etapa => etapa.Id == id && etapa.Valid && etapa.Fases.Any(fase => fase.EtapaId == etapa.Id && fase.Valid));
        return etapaEncontrada == null ? NotFound() : Ok(_mapper.Map<EtapaReadDto>(etapaEncontrada));
    }

    [HttpGet("Fases/{id}")]
    public IActionResult RecuperaEtapaComFasesComId(int id)
    {
        Etapa etapaEncontrada = _context.Etapas.FirstOrDefault(etapa => etapa.Id == id && etapa.Valid && etapa.Fases.Any(fase => fase.EtapaId == etapa.Id && fase.Valid));
        return etapaEncontrada == null ? NotFound() : Ok(_mapper.Map<EtapaWithFasesReadDto>(etapaEncontrada));
    }

    [HttpGet("Deleted")]
    public IEnumerable<EtapaWithFasesReadDto> RecuperaEtapasQueForamDeletadas([FromQuery] int skip = 0, [FromQuery] int take = 3)
    {
        return _mapper.Map<List<EtapaWithFasesReadDto>>(_context.Etapas.Where(etapa => !etapa.Valid).Skip(skip).Take(take).ToList());
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEtapa(int id, [FromBody] EtapaUpdateDto etapaDto)
    {
        var etapa = _context.Etapas.FirstOrDefault(etapa => etapa.Id == id && etapa.Valid);
        if (etapa == null) return NotFound();

        _mapper.Map(etapaDto, etapa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaEtapaParcial(int id, JsonPatchDocument<EtapaUpdateDto> patch)
    {
        var etapa = _context.Etapas.FirstOrDefault(etapa => etapa.Id == id && etapa.Valid);
        if (etapa == null) return NotFound();

        var etapaAtualizar = _mapper.Map<EtapaUpdateDto>(etapa);
        patch.ApplyTo(etapaAtualizar, ModelState);
        if (!TryValidateModel(etapaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(etapaAtualizar, etapa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaEtapa(int id)
    {
        var etapa = _context.Etapas.FirstOrDefault(etapa => etapa.Id == id && etapa.Valid);
        if (etapa == null) return NotFound();

        etapa.Valid = false;
        _context.Update(etapa);
        _context.SaveChanges();
        return NoContent();
    }

    //[HttpDelete("{id}")]
    //public IActionResult DeletaEtapa(int id)
    //{
    //    var etapa = _context.Etapas.FirstOrDefault(etapa => etapa.Id == id);
    //    if (etapa == null) return NotFound();

    //    _context.Remove(etapa);
    //    _context.SaveChanges();
    //    return NoContent();
    //}

}
