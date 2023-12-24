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

    return CreatedAtAction(nameof(SessaoPorId), new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, sessaoDto);
  }

  [HttpGet]
  public IEnumerable<ReadSessaoDto> TodasSessoes()
  {
    return _mapper.Map<List<ReadSessaoDto>>(_context.Sessaos.ToList());
  }

  [HttpGet("{filmeId}/{cinemaId}")]
  public IActionResult SessaoPorId(int filmeId, int cinemaId)
  {
    Sessao? sessao = _context.Sessaos.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
    if (sessao == null)
    {
      return NotFound();
    }
    return Ok(sessao);
  }

  [HttpPut("{filmeId}/{cinemaId}")]
  public IActionResult AtualizaSessao(int filmeId, int cinemaId, [FromBody] UpdateSessaoDto updateSessaoDto)
  {
    Sessao? sessao = _context.Sessaos.FirstOrDefault(s => s.FilmeId == filmeId && s.CinemaId == cinemaId);
    if (sessao == null)
    {
      return NotFound();
    }
    _mapper.Map(updateSessaoDto, sessao);
    _context.SaveChanges();
    return NoContent();
  }


  [HttpDelete("{filmeId}/{sessaoId}")]
  public IActionResult RemoveSessao(int filmeId, int sessaoId)
  {
    Sessao? sessao = _context.Sessaos.FirstOrDefault(s => s.FilmeId == filmeId && s.CinemaId  == sessaoId);
    if (sessao == null)
    {
      return NotFound();
    }
    _context.Sessaos.Remove(sessao);
    _context.SaveChanges();
    return NoContent();
  }
}
