using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SGBIMFurnas.Data;
using SGBIMFurnas.Dtos.FaseDto;
using SGBIMFurnas.Dtos.TransicaoDto;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Controllers;

[ApiController]
[Route("[controller]")]
public class FaseController : ControllerBase
{
    private DatabaseContext _context;
    private IMapper _mapper;

    public FaseController(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CriaFase([FromBody] FaseCreateDto faseDto)
    {
        Fase fase = _mapper.Map<Fase>(faseDto);
        _context.Fases.Add(fase);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFaseComId), new { id = fase.Id }, fase);
    }

    [HttpGet]
    public IEnumerable<FaseWithEtapaReadDto> RecuperaFases([FromQuery] int skip = 0, [FromQuery] int take = 15)
    {
        return _mapper.Map<List<FaseWithEtapaReadDto>>(_context.Fases.Where(fase => fase.Valid).Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFaseComId(int id)
    {
        Fase faseEncontrada = _context.Fases.FirstOrDefault(fase => fase.Id == id && fase.Valid);
        return faseEncontrada == null ? NotFound() : Ok(_mapper.Map<FaseWithSeguintesReadDto>(faseEncontrada));
    }

    [HttpGet("deleted")]
    public IEnumerable<FaseWithEtapaReadDto> RecuperaFasesQueForamDeletadas([FromQuery] int skip = 0, [FromQuery] int take = 3)
    {
        return _mapper.Map<List<FaseWithEtapaReadDto>>(_context.Fases.Where(fase => !fase.Valid).Skip(skip).Take(take));
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFase(int id, [FromBody] FaseUpdateDto faseDto)
    {
        var fase = _context.Fases.FirstOrDefault(fase => fase.Id == id && fase.Valid);
        if (fase == null) return NotFound();

        _mapper.Map(faseDto, fase);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFaseParcial(int id, JsonPatchDocument<FaseUpdateDto> patch)
    {
        var fase = _context.Fases.FirstOrDefault(fase => fase.Id == id && fase.Valid);
        if (fase == null) return NotFound();

        var faseAtualizar = _mapper.Map<FaseUpdateDto>(fase);
      
        patch.ApplyTo(faseAtualizar, ModelState);
        if (!TryValidateModel(faseAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(faseAtualizar, fase);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFase(int id)
    {
        var fase = _context.Fases.FirstOrDefault(fase => fase.Id == id && fase.Valid);
        if (fase == null) return NotFound();

        fase.Valid = false;
        _context.Update(fase);
        _context.SaveChanges();
        return NoContent();
    }

    // FaseTransição
    [HttpPost("transicao")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CriaTransicao([FromBody] FaseTransicaoCreateDto transicaoDto)
    {
        FaseTransicao transicao = _mapper.Map<FaseTransicao>(transicaoDto);
        _context.FaseTransicao.Add(transicao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaTransicaoComId), new { id = transicao.FaseAnteriorId }, transicao);
    }

    [HttpGet("transicao")]
    public IEnumerable<FaseTransicaoReadDto> RecuperaTransicao([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<FaseTransicaoReadDto>>(_context.FaseTransicao.Skip(skip).Take(take).ToList());
    }

    [HttpGet("transicao/{id}")]
    public IEnumerable<FaseTransicaoReadDto> RecuperaTransicaoComId(int id, [FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<FaseTransicaoReadDto>>(_context.FaseTransicao
            .Where(transicao => transicao.FaseAnteriorId == id || transicao.FaseSeguinteId == id )
            .Skip(skip).Take(take).ToList());
    }

    [HttpDelete("transicao/{AnteriorId}/{SeguinteId}")]
    public IActionResult DeletaTransicao(int AnteriorId, int SeguinteId)
    {
        var transicao = _context.FaseTransicao.FirstOrDefault(transicao => transicao.FaseAnteriorId == AnteriorId 
                                                                        && transicao.FaseSeguinteId == SeguinteId);
        if (transicao == null) return NotFound();

        _context.Remove(transicao);
        _context.SaveChanges();
        return NoContent();
    }
}
