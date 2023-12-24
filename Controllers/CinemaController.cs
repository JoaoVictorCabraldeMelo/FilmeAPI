using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("api/cinema")]
public class CinemaController : ControllerBase
{
    private readonly FilmeContext _context;

    private readonly IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();

        return CreatedAtAction(nameof(CinemaPorId), new { id =  cinema.Id }, cinemaDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> TodosCinemas()
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult CinemaPorId(int id)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if(cinema == null)
        {
            return NotFound();
        }
        return Ok(cinema);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto updateCinemaDto)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _mapper.Map(updateCinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult RemoveCinema(int id) 
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}
