namespace NoteKeeper.WebApi.ViewModels
{
    public class ListarNotaViewModel
    {
        public required Guid Id { get; set; }
        public required string Titulo { get; set; }
    }

    public class VisualizarNotaViewModel
    {
        public required Guid Id;
        public required string Titulo { get; set; }
        public required string Conteudo { get; set; }
        public required bool Arquivada { get; set; }
        public required ListarCategoriaViewModel Categoria { get; set; }
    }

    public class FormsNotaViewModel
    {
        public required string Titulo { get; set; }
        public required string Conteudo { get; set; }
        public required bool Arquivada { get; set; }
        public required Guid CategoriaId { get; set; }
    }

    public class InserirNotaViewModel : FormsNotaViewModel
    {
    }

    public class EditarNotaViewModel : FormsNotaViewModel
    {
    }


}
