using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.Dtos;

namespace FilmeAPI.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        CreateMap<Endereco, UpdateEnderecoDto>();
    }
}
