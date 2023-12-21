using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models.Dtos;

public class UpdateEnderecoDto : Profile
{
    [MaxLength(100)]
    public string Logradouro { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int Numero { get; set; }
}
