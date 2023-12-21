using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Models;
using FilmeAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("endereco")]
public class EnderecoController : ControllerBase
{
    private readonly FilmeContext _context;

    private readonly IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();

        return CreatedAtAction(nameof(EnderecoPorId), new { id = endereco.Id }, enderecoDto);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> TodosEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult EnderecoPorId(int id)
    {
        Endereco? endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        return Ok(endereco);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto updateEnderecoDto)
    {
        Endereco? endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        _mapper.Map(updateEnderecoDto, endereco);
        _context.SaveChanges();
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
        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }

}
