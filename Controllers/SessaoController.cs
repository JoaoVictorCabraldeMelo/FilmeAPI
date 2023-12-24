using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI;

[ApiController]
[Route("api/sessao")]
public class SessaoController : ControllerBase
{
  private readonly FilmeContext _context;

  private readonly IMapper _mapper;

  public SessaoController(FilmeContext context, IMapper mapper) 
  {
    _context = context;
    _mapper = mapper;
  }


  [HttpPost]
  public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
  {
    Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
    _context.Sessaos.Add(sessao);
    _context.SaveChanges();

    return CreatedAtAction(nameof(SessaoPorId), new { id = sessao.Id }, sessaoDto);
  }

  [HttpGet]
  public IEnumerable<ReadSessaoDto> TodasSessoes()
  {
    return _mapper.Map<List<ReadSessaoDto>>(_context.Sessaos.ToList());
  }

  [HttpGet("{id}")]
  public IActionResult SessaoPorId(int id)
  {
    Sessao? sessao = _context.Sessaos.FirstOrDefault(c => c.Id == id);
    if (sessao == null)
    {
      return NotFound();
    }
    return Ok(sessao);
  }

  [HttpPut("{id}")]
  public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto updateSessaoDto)
  {
    Sessao? sessao = _context.Sessaos.FirstOrDefault(s => s.Id == id);
    if (sessao == null)
    {
      return NotFound();
    }
    _mapper.Map(updateSessaoDto, sessao);
    _context.SaveChanges();
    return NoContent();
  }


  [HttpDelete("{id}")]
  public IActionResult RemoveSessao(int id)
  {
    Sessao? sessao = _context.Sessaos.FirstOrDefault(s => s.Id == id);
    if (sessao == null)
    {
      return NotFound();
    }
    _context.Sessaos.Remove(sessao);
    _context.SaveChanges();
    return NoContent();
  }
}
