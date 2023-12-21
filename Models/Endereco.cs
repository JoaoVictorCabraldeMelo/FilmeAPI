using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Logradouro { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int Numero { get; set; }

    public virtual Cinema? Cinema { get; set; }
}
