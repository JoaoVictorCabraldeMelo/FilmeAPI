using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.Dtos;

namespace FilmeAPI.Profiles;

/// <summary>
/// Mapper for profile in EnderecoProfile for mapping to his Dtos
/// </summary>
public class EnderecoProfile : Profile
{
    /// <summary>
    /// Constructor for profiles
    /// </summary>
    public EnderecoProfile()
    {
        _ = CreateMap<Endereco, ReadEnderecoDto>();
        _ = CreateMap<CreateEnderecoDto, Endereco>();
        _ = CreateMap<UpdateEnderecoDto, Endereco>();
        _ = CreateMap<Endereco, UpdateEnderecoDto>();
    }
}
