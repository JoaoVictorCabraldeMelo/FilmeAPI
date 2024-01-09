using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.Dtos;

namespace FilmeAPI.Profiles;

/// <summary>
/// Class representing the configurations of sessao profile and others configurations
/// </summary>
public class SessaoProfile : Profile
{

    /// <summary>
    /// Constructor initializing configs of the sessao to map for his dtos
    /// </summary>
    public SessaoProfile()
    {
        _ = CreateMap<CreateSessaoDto, Sessao>();
        _ = CreateMap<Sessao, ReadSessaoDto>();
        _ = CreateMap<Sessao, UpdateSessaoDto>();
        _ = CreateMap<UpdateSessaoDto, Sessao>();
    }
}
