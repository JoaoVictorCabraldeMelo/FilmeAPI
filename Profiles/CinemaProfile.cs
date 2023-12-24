using AutoMapper;
using FilmeAPI.Models.Dtos;

namespace FilmeAPI.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, UpdateCinemaDto>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(dto => dto.ReadEnderecoDto, opt => opt.MapFrom(cinema => cinema.Endereco));
    }
}
