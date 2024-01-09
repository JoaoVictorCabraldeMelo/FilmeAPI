using AutoMapper;
using FilmeAPI.Models.Dtos;
using FilmeAPI.Models;

namespace FilmeAPI.Profiles;

/// <summary>
/// Class for mapping Cinema and other Dtos related to the cinema 
/// </summary>
public class CinemaProfile : Profile
{

    /// <summary>
    /// Constructor of Cinema Profile this where the configs of the cinema architecture are in
    /// </summary>
    public CinemaProfile()
    {
        _ = CreateMap<CreateCinemaDto, Cinema>();
        _ = CreateMap<UpdateCinemaDto, Cinema>();
        _ = CreateMap<Cinema, UpdateCinemaDto>();
        _ = CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(dto => dto.ReadEnderecoDto, opt => opt.MapFrom(cinema => cinema.Endereco))
            .ForMember(cinemaDto => cinemaDto.Sessoes, opt => opt.MapFrom(cinema => cinema.Sessoes));
    }
}
