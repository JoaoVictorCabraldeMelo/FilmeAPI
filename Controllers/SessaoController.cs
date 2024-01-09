using AutoMapper;
using FilmeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using FilmeAPI.Models.Dtos;
using FilmeAPI.Models;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("api/sessao")]
public class SessaoController(FilmeContext context, IMapper mapper) : ControllerBase
{
    private readonly FilmeContext _context = context;

    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
    {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
        _ = _context.Sessaos.Add(sessao);
        _ = _context.SaveChanges();

        return CreatedAtAction(nameof(SessaoPorId), new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, sessaoDto);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> TodasSessoes() => _mapper.Map<List<ReadSessaoDto>>(_context.Sessaos.ToList());

    [HttpGet("{filmeId}/{cinemaId}")]
    public IActionResult SessaoPorId(int filmeId, int cinemaId)
    {
        Sessao? sessao = _context.Sessaos.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
        return sessao == null ? NotFound() : Ok(sessao);
    }

    [HttpPut("{filmeId}/{cinemaId}")]
    public IActionResult AtualizaSessao(int filmeId, int cinemaId, [FromBody] UpdateSessaoDto updateSessaoDto)
    {
        Sessao? sessao = _context.Sessaos.FirstOrDefault(s => s.FilmeId == filmeId && s.CinemaId == cinemaId);
        if (sessao == null)
        {
            return NotFound();
        }
        _ = _mapper.Map(updateSessaoDto, sessao);
        _ = _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{filmeId}/{sessaoId}")]
    public IActionResult RemoveSessao(int filmeId, int sessaoId)
    {
        Sessao? sessao = _context.Sessaos.FirstOrDefault(s => s.FilmeId == filmeId && s.CinemaId == sessaoId);
        if (sessao == null)
        {
            return NotFound();
        }
        _ = _context.Sessaos.Remove(sessao);
        _ = _context.SaveChanges();
        return NoContent();
    }
}
