using System.ComponentModel.DataAnnotations;

namespace FilmeAPI;

public class CreateSessaoDto
{

    [Required]
    [MaxLength(50, ErrorMessage = "Lugar da sessao deve ter no maximo  50 caracteres")]
    public string Lugar { get; set; } = string.Empty;


    [Required]
    public int FilmeId { get; set; }

    public int CinemaId { get; set; }

}
