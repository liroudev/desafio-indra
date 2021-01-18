using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.API.Model
{
    [Table("Livros")]
    public class Livro
    {

        public Livro() { }
        public Livro(int id, string titulo, string subtitulo, int quantidadePagina, int anoPublicacao, string versao)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Subtitulo = subtitulo;
            this.QuantidadePagina = quantidadePagina;
            this.AnoPublicacao = anoPublicacao;
            this.Versao = versao;

        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public int QuantidadePagina { get; set; }
        public int AnoPublicacao { get; set; }
        public string Versao { get; set; }

        public ICollection<LivroAutor> LivrosAutores { get;set;}
    }
}