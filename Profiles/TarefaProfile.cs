using AutoMapper;
using SGBIMFurnas.Dtos.TarefaDto;
using SGBIMFurnas.Models;

namespace SGBIMFurnas.Profiles;

public class TarefaProfile : Profile
{
    public TarefaProfile()
    {
        CreateMap<TarefaCreateDto, Tarefa>();
        CreateMap<TarefaUpdateDto, Tarefa>();
        CreateMap<Tarefa, TarefaUpdateDto>();
        CreateMap<Tarefa, TarefaReadDto>()
            .ForMember(tarefaDto => tarefaDto.Fase, opt => opt.MapFrom(tarefa => tarefa.Fase));
        CreateMap<Tarefa, TarefaAnteriorReadDto>()
            .ForMember(tarefaDto => tarefaDto.Fase, opt => opt.MapFrom(tarefa => tarefa.Fase))
            .ForMember(tarefaDto => tarefaDto.TarefaAnterior, opt => opt.MapFrom(tarefa => tarefa.TarefaAnterior));
        CreateMap<Tarefa, TarefaSeguinteReadDto>()
            .ForMember(tarefaDto => tarefaDto.Fase, opt => opt.MapFrom(tarefa => tarefa.Fase))
            .ForMember(tarefaDto => tarefaDto.TarefaSeguinte, opt => opt.MapFrom(tarefa => tarefa.TarefaSeguinte));
    }
}
