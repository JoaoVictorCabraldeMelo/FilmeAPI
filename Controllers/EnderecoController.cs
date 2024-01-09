using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Models;
using FilmeAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("api/endereco")]
public class EnderecoController(FilmeContext context, IMapper mapper) : ControllerBase
{
    private readonly FilmeContext _context = context;

    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _ = _context.Enderecos.Add(endereco);
        _ = _context.SaveChanges();

        return CreatedAtAction(nameof(EnderecoPorId), new { id = endereco.Id }, enderecoDto);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> TodosEnderecos() => _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());

    [HttpGet("{id}")]
    public IActionResult EnderecoPorId(int id)
    {
        Endereco? endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        return endereco == null ? NotFound() : Ok(endereco);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto updateEnderecoDto)
    {
        Endereco? endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        _ = _mapper.Map(updateEnderecoDto, endereco);
        _ = _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult RemoveEndereco(int id)
    {
        Endereco? endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        _ = _context.Enderecos.Remove(endereco);
        _ = _context.SaveChanges();
        return NoContent();
    }

}
