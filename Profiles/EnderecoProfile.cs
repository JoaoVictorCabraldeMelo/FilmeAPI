using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.Dtos;

namespace FilmeAPI.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        _ = CreateMap<Endereco, ReadEnderecoDto>();
        _ = CreateMap<CreateEnderecoDto, Endereco>();
        _ = CreateMap<UpdateEnderecoDto, Endereco>();
        _ = CreateMap<Endereco, UpdateEnderecoDto>();
    }
}
