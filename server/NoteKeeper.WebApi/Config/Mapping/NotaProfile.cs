using AutoMapper;
using NoteKeeper.Dominio.ModuloNota;
using NoteKeeper.WebApi.Config.Mapping.Actions;
using NoteKeeper.WebApi.ViewModels;

namespace NoteKeeper.WebApi.Config.Mapping
{
    public class NotaProfile : Profile
    {
        public NotaProfile()
        {
            CreateMap<Nota, ListarNotaViewModel>();
            CreateMap<Nota, VisualizarNotaViewModel>();

            CreateMap<FormsNotaViewModel, Nota>()
                .AfterMap<ConfigurarCategoriaMappingAction>();
        }
    }
}


