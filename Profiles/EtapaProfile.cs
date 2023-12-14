using AutoMapper;
using SGBIMFurnas.Dtos;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Profiles;

public class EtapaProfile : Profile
{
    public EtapaProfile() {
        CreateMap<EtapaCreateDto, Etapa>();
        CreateMap<EtapaUpdateDto, Etapa>();
        CreateMap<Etapa, EtapaUpdateDto>();
        CreateMap<Etapa, EtapaReadDto>();
    }
}
