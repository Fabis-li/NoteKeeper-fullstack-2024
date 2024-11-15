using AutoMapper;
using NoteKeeper.Dominio.ModuloAutenticacao;
using NoteKeeper.WebApi.ViewModels;

namespace NoteKeeper.WebApi.Config.Mapping;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<RegistrarUsuarioViewModel, Usuario>();
    }
}
