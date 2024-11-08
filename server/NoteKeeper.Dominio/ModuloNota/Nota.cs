using NoteKeeper.Dominio.Compartilhado;
using NoteKeeper.Dominio.ModuloCategoria;

namespace NoteKeeper.Dominio.ModuloNota
{
    public class Nota : Entidade
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool Arquivada { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        protected Nota()
        {
        }

        public Nota(string titulo, string conteudo, Guid categoriaId) : this()
        {
            Titulo = titulo;
            Conteudo = conteudo;
            CategoriaId = categoriaId;
        }

        public override List<string> Validar()
        {
            List<string> erros = [];

            if (string.IsNullOrEmpty(Titulo))
                erros.Add("O título é obrigatório");

            if (string.IsNullOrEmpty(Conteudo))
                erros.Add("O conteúdo é obrigatório");

            if (CategoriaId == Guid.Empty)
                erros.Add("A categoria é obrigatória");

            return erros;
        }
    }
}
