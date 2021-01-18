using System.Threading.Tasks;
using Livraria.API.Dto;
using Livraria.API.Model;

namespace Livraria.API.Data
{
    public interface IRepository
    {
        //Geral
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();

        //Livro
         Task<Livro[]> GetAllLivrosAsync();
         Task<LivroDto[]> GetAllLivrosDtoAsync();
         Task<Livro> GetLivroByIdAsync(int livroId);
         Task<LivroDto> GetLivroDtoByIdAsync(int livroId);
         Task<LivroDto> GetLivroDtoByAutorIdAsync(int autorId);

         //Autor
         Task<Autor[]> GetAllAutoresAsync();
         Task<AutorDto[]> GetAllAutoresDtoAsync();
         Task<AutorDto> GetAutorDtoByIdAsync(int autorId);
         Task<Autor> GetAutorByIdAsync(int autorId);
         Task<Autor[]> GetAutoresBylivroId(int livroId);
    }
}