using System.ComponentModel.DataAnnotations;

namespace FilmeAPI;

public class CreateCinemaDto
{
  [Required(ErrorMessage = "O campo do nome e obrigatorio")]
  public string Nome { get; set; } = string.Empty;

    public int EnderecoId { get; set; }
}
