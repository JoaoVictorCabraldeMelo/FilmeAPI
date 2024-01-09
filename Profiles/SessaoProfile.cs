using AutoMapper;

namespace FilmeAPI;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        _ = CreateMap<CreateSessaoDto, Sessao>();
        _ = CreateMap<Sessao, ReadSessaoDto>();
        _ = CreateMap<Sessao, UpdateSessaoDto>();
        _ = CreateMap<UpdateSessaoDto, Sessao>();
    }
}
