using AutoMapper;
using SGBIMFurnas.Dtos.TransicaoDto;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Profiles;

public class FaseTransicaoProfile : Profile
{
    public FaseTransicaoProfile()
    {
        CreateMap<FaseTransicaoCreateDto, FaseTransicao>();
        CreateMap<FaseTransicao, FaseTransicaoReadDto>()
            .ForMember(faseDto => faseDto.FaseAnterior, opt => opt.MapFrom(fase => fase.FaseAnterior))
            .ForMember(faseDto => faseDto.FaseSeguinte, opt => opt.MapFrom(fase => fase.FaseSeguinte));
        CreateMap<FaseTransicao, FaseTransicaoAnteriorReadDto>()
            .ForMember(faseDto => faseDto.FaseAnterior, opt => opt.MapFrom(fase => fase.FaseAnterior));
        CreateMap<FaseTransicao, FaseTransicaoSeguinteReadDto>()
            .ForMember(faseDto => faseDto.FaseSeguinte, opt => opt.MapFrom(fase => fase.FaseSeguinte));
    }
}
