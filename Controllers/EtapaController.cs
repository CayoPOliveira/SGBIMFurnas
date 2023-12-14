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
    private EtapaContext _context;
    private IMapper _mapper;

    public EtapaController(EtapaContext context, IMapper mapper) { 
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
    public IEnumerable<EtapaReadDto> RecuperaEtapas([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<EtapaReadDto>>(_context.Etapas.Where(etapa => etapa.Valid).Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEtapaComId(int id)
    {
        Etapa etapaEncontrada = _context.Etapas.FirstOrDefault(etapa => etapa.Id == id && etapa.Valid);
        return etapaEncontrada == null ? NotFound() : Ok(_mapper.Map<EtapaReadDto>(etapaEncontrada));
    }

    [HttpGet("deleted")]
    public IEnumerable<EtapaReadDto> RecuperaEtapasQueForamDeletadas([FromQuery] int skip = 0, [FromQuery] int take = 3)
    {
        return _mapper.Map<List<EtapaReadDto>>(_context.Etapas.Where(etapa => !etapa.Valid).Skip(skip).Take(take));
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
