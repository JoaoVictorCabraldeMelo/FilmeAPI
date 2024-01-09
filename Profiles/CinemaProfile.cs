using AutoMapper;
using FilmeAPI.Models.Dtos;

namespace FilmeAPI.Profiles;

public class CinemaProfile : Profile
{
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
