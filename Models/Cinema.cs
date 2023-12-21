

using FilmeAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmeAPI;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo do nome e obrigatorio")]
    public string Nome { get; set; } = string.Empty;

    public int EnderecoId { get; set; }

    public virtual Endereco Endereco { get; set; }
}
