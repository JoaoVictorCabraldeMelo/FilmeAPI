using AutoMapper;
using FilmeAPI.Models.Dtos;
using FilmeAPI.Models;

namespace FilmeAPI.Profiles;

/// <summary>
/// Class for mapping Filme Profile using his Dtos 
/// </summary>
public class FilmeProfile : Profile
{
    /// <summary>
    /// Constructor for mapping filme profiles
    /// </summary>
    public FilmeProfile()
    {
        _ = CreateMap<CreateFilmeDto, Filme>();
        _ = CreateMap<UpdateFilmeDto, Filme>();
        _ = CreateMap<Filme, UpdateFilmeDto>();
        _ = CreateMap<Filme, ReadFilmeDto>()
          .ForMember(filmeDto => filmeDto.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes));
    }

}