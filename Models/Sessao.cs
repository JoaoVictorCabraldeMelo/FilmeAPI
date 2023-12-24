using System.ComponentModel.DataAnnotations;
using FilmeAPI.Models;

namespace FilmeAPI;

public class Sessao
{
  [Key]
  [Required]
  public int Id { get; set; }

  [Required]
  [MaxLength(50, ErrorMessage = "Lugar da sessao deve ter no maximo  50 caracteres")]
  public string Lugar { get; set; } = string.Empty;

  [Required]
  public int FilmeId { get; set; }

  public virtual Filme Filme { get; set; }
}
