using System.ComponentModel.DataAnnotations;

namespace FilmeAPI;

public class CinemaDto
{
  [Required(ErrorMessage = "O campo do nome e obrigatorio")]
  public string Nome { get; set; }
}
