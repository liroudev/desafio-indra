using System.Collections.Generic;
using Livraria.API.Model;

namespace Livraria.API.Dto
{
    public class AutorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Pais { get; set; }

        public IEnumerable<Livro> Livros { get;set;}
        
    }
}