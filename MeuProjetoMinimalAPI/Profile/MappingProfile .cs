using AutoMapper;
using MeuProjetoMinimalAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<Result, ClienteDTO>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Level.Customer))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Rock, opt => opt.MapFrom(src => src.Level.LevelDescription))
               .ForMember(dest => dest.ContaBemol, opt => opt.MapFrom(src => src.BonusStatement.results.Any(bs => bs.EntryCode == "74")));
    }
}



