namespace NoteKeeper.WebApi.ViewModels
{
    public class InserirCategoriaViewModel
    {
        public required string Titulo { get; set; }
    }

    public class EditarCategoriaViewModel
    {
        public required string Titulo { get; set; }
    }

    public class ListarCategoriaViewModel
    {
        public required Guid Id { get; set; }

        public required string Titulo { get; set; }
    }

    public class VisualizarCategoriaViewModel
    {
        public required Guid Id { get; set; }

        public required string Titulo { get; set; }

        public required List<ListarNotaViewModel> Notas { get; set; }
    }
}