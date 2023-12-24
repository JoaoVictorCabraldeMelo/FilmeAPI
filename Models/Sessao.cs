using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmeAPI.Models;

namespace FilmeAPI;

public class Sessao
{

  [Required]
  [MaxLength(50, ErrorMessage = "Lugar da sessao deve ter no maximo  50 caracteres")]
  public string Lugar { get; set; } = string.Empty;

  [ForeignKey(nameof(Filme))]
  public int? FilmeId { get; set; }

  public virtual Filme Filme { get; set; }

  [ForeignKey(nameof(Cinema))]
  public int? CinemaId { get; set; }

  public virtual Cinema Cinema { get; set; }
}
