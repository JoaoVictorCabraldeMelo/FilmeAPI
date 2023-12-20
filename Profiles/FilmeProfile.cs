using AutoMapper;
using FilmeAPI.Models.Dtos;
using FilmeAPI.Models;

namespace FilmeAPI.Profiles;

public class FilmeProfile : Profile
{
  public FilmeProfile()
  {
    CreateMap<CreateFilmeDto, Filme>();
    CreateMap<UpdateFilmeDto, Filme>();
    CreateMap<Filme, UpdateFilmeDto>();
    CreateMap<Filme, ReadFilmeDto>();
  }
  
}