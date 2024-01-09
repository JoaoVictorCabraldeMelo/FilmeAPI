using AutoMapper;
using FilmeAPI.Models.Dtos;
using FilmeAPI.Models;

namespace FilmeAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        _ = CreateMap<CreateFilmeDto, Filme>();
        _ = CreateMap<UpdateFilmeDto, Filme>();
        _ = CreateMap<Filme, UpdateFilmeDto>();
        _ = CreateMap<Filme, ReadFilmeDto>()
          .ForMember(filmeDto => filmeDto.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes));
    }

}