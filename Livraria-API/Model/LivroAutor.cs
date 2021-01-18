using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.API.Model
{
    [Table("LivrosAutores")]
    public class LivroAutor
    {
        public LivroAutor(){ }
        public LivroAutor(int livroId,  int autorId)
        {
            this.LivroId = livroId;
            this.AutorId = autorId;
        }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}