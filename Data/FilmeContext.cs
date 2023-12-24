using FilmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Data;


public class FilmeContext : DbContext
{

    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    {
    
    }

    public DbSet<Filme> Filmes { get; set; }

    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Endereco> Enderecos { get; set; }

    public DbSet<Sessao> Sessaos { get; set; }
}

