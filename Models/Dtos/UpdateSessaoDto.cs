using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models.Dtos;

public class UpdateSessaoDto
{
    [MaxLength(50, ErrorMessage = "Lugar da sessao deve ter no maximo  50 caracteres")]
    public string Lugar { get; set; } = string.Empty;

    public int FilmId { get; set; }

}
