

using System.ComponentModel.DataAnnotations;

namespace FilmeAPI;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo do nome e obrigatorio")]
    public string Nome { get; set; }
}
