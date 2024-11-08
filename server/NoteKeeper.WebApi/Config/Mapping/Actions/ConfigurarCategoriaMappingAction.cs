using AutoMapper;
using NoteKeeper.Dominio.ModuloCategoria;
using NoteKeeper.Dominio.ModuloNota;
using NoteKeeper.WebApi.ViewModels;

namespace NoteKeeper.WebApi.Config.Mapping.Actions
{
    public class ConfigurarCategoriaMappingAction : IMappingAction<FormsNotaViewModel, Nota>
    {
        private readonly IRepositorioCategoria repositorioCategoria;

        public ConfigurarCategoriaMappingAction(IRepositorioCategoria repositorioCategoria)
        {
            this.repositorioCategoria = repositorioCategoria;
        }

        public void Process(FormsNotaViewModel source, Nota destination, ResolutionContext context)
        {
            var idCategoria = source.CategoriaId;

            destination.Categoria = repositorioCategoria.SelecionarPorId(idCategoria);
        }
    }
}


