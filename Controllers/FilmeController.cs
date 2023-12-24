using Microsoft.AspNetCore.Mvc;
using FilmeAPI.Models;
using FilmeAPI.Data;
using FilmeAPI.Models.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("api/filme")]
public class FilmeController : ControllerBase
{
    private readonly FilmeContext _context;

    private readonly IMapper _map;

    public FilmeController(FilmeContext context, IMapper map)
    {
        _context = context;
        _map = map;
    }


    
    ///    <summary>
    ///        Adiciona um filme ao banco de dados
    ///    </summary>
    ///    <param name="filmeDto">Objeto com os campos necessarios para criacao de um filme</param>
    ///    <returns>IActionResult</returns>
    ///    <response code="201"> Caso insercao seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _map.Map<Filme>(filmeDto);
        
        _context.Filmes.Add(filme);

        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperarFilme), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> TodosFilmes([FromQuery] int pagina = 0, [FromQuery] int tamanho = 50, [FromQuery] string? nomeCinema = null)
    {
        if (nomeCinema == null) {
            pagina = pagina * 10;

            return _map.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(pagina).Take(tamanho).ToList());
        }
        return _map.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(pagina).Take(tamanho).Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome == nomeCinema)).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound(filme);
        var filmeDto = _map.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) return NotFound();

        _map.Map(filmeDto, filme);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) return NotFound();

        var filmeParaAtualizar = _map.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if(!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _map.Map(filmeParaAtualizar, filme);

        _context.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        
        _context.Remove(filme);

        _context.SaveChanges();

        return NoContent();
    }
}