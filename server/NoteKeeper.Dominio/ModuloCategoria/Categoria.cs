using NoteKeeper.Dominio.Compartilhado;
using NoteKeeper.Dominio.ModuloNota;

namespace NoteKeeper.Dominio.ModuloCategoria
{
    public class Categoria : Entidade
    {
        public string Titulo { get; set; }

        public List<Nota> Notas { get; set; }

        protected Categoria()
        {
            Notas = [];
        }

        public Categoria(string titulo) : this()
        {
            Titulo = titulo;
        }

        public override List<string> Validar()
        {
            List<string> erros = [];

            if (string.IsNullOrEmpty(Titulo))
                erros.Add("O título é obrigatório");

            return erros;
        }
    }
}
