using AutoMapper;
using SGBIMFurnas.Dtos.CargoDto;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Profiles;

public class CargoProfile : Profile
{
    public CargoProfile()
    {
        CreateMap<CargoCreateDto, Cargo>();
        CreateMap<CargoUpdateDto, Cargo>();
        CreateMap<Cargo, CargoUpdateDto>();
        CreateMap<Cargo, CargoReadDto>();
    }
}
