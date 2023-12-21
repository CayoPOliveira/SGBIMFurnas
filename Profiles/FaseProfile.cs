using AutoMapper;
using SGBIMFurnas.Dtos.FaseDto;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Profiles;

public class FaseProfile : Profile
{
    public FaseProfile()
    {
        CreateMap<FaseCreateDto, Fase>();
        CreateMap<FaseUpdateDto, Fase>();
        CreateMap<Fase, FaseUpdateDto>();
        CreateMap<Fase, FaseReadDto>();
        CreateMap<Fase, FaseWithEtapaReadDto>()
            .ForMember(faseDto => faseDto.Etapa, opt => opt.MapFrom(fase => fase.Etapa));
        CreateMap<Fase, FaseWithAnterioresReadDto>()
            .ForMember(faseDto => faseDto.Etapa, opt => opt.MapFrom(fase => fase.Etapa))
            .ForMember(faseDto => faseDto.FasesAnteriores, opt => opt.MapFrom(fase => fase.FasesAnteriores));
        CreateMap<Fase, FaseWithSeguintesReadDto>()
            .ForMember(faseDto => faseDto.Etapa, opt => opt.MapFrom(fase => fase.Etapa))
            .ForMember(faseDto => faseDto.FasesSeguintes, opt => opt.MapFrom(fase => fase.FasesSeguintes));
    }
}
