using AutoMapper;

namespace FilmeAPI;

public class SessaoProfile : Profile
{
  public SessaoProfile()
  {
    CreateMap<CreateSessaoDto, Sessao>();
    CreateMap<Sessao, ReadSessaoDto>();    
    CreateMap<Sessao, UpdateSessaoDto>();
    CreateMap<UpdateSessaoDto, Sessao>();
  }
}
