using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public ReadEnderecoDto? ReadEnderecoDto { get; set; }

    public ICollection<ReadSessaoDto> Sessoes { get; set; } = new List<ReadSessaoDto>();

}
