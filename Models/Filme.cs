using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models;

public class Filme
{
    [Key]
    [Required(ErrorMessage = "O Id deve ser obrigatorio")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O Titulo do filme e obrigatorio")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Genero do filme e obrigatorio")]
    [MaxLength(50, ErrorMessage = "O Genero nao pode passar de 50 caracteres")]
    public string Genero { get; set; } = string.Empty;

    [Required(ErrorMessage = "A Duracao do filme e obrigatorio")]
    [Range(70, 600, ErrorMessage = "A Duracao deve ser entre 70 min ha 600 min")]
    public int Duracao { get; set; }
}