using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.API.Model
{
    [Table("Autores")]
    public class Autor
    {
        public Autor(){ }
        public Autor(int id, string nome, string sobreNome, string pais)
        {
            this.Id = id;
            this.Nome = nome;
            this.SobreNome = sobreNome;
            this.Pais = pais;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Pais { get; set; }
        public string NomeCompleto 
        {
            get
            {
                return $"{this.Nome} {this.SobreNome}";
            }
        }

        public ICollection<LivroAutor> LivrosAutores { get;set;}
    }
}