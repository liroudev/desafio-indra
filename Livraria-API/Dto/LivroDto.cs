using System.Collections.Generic;
using Livraria.API.Model;

namespace Livraria.API.Dto
{
    public class LivroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public int QuantidadePagina { get; set; }
        public int AnoPublicacao { get; set; }
        public string Versao { get; set; }

        public IEnumerable<Autor> Autores { get;set;}
    }
}