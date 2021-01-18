using System.Linq;
using System.Threading.Tasks;
using Livraria.API.Dto;
using Livraria.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Livraria.API.Data
{
    public class Repository : IRepository
    {
        
        private DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }        

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Livro[]> GetAllLivrosAsync()
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.Include(la=> la.LivrosAutores)
                         .ThenInclude(a => a.Autor);

            query = query.OrderBy(x=>x.Id);

            return await query.ToArrayAsync();
            
        }

        public async Task<LivroDto[]> GetAllLivrosDtoAsync()
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.Include(la=> la.LivrosAutores)
                         .ThenInclude(a => a.Autor);

            var livrosDto = query.Select(l => new LivroDto{
                Id = l.Id,
                Titulo = l.Titulo,
                Subtitulo = l.Subtitulo,
                QuantidadePagina = l.QuantidadePagina,
                AnoPublicacao = l.AnoPublicacao,
                Versao = l.Versao,
                Autores = l.LivrosAutores.Select(a => a.Autor).ToArray()
            }).AsNoTracking()
              .OrderBy(l => l.Id);

            return await livrosDto.ToArrayAsync();
            
        }        

        public async Task<Livro> GetLivroByIdAsync(int livroId)
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.Include(la => la.LivrosAutores)
                         .ThenInclude(a => a.Autor);

            query = query.AsNoTracking()
                         .OrderBy(l => l.Id)
                         .Where(l => l.Id == livroId);

            return await query.FirstOrDefaultAsync();

        }

        public async Task<LivroDto> GetLivroDtoByIdAsync(int livroId)
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.Include(la => la.LivrosAutores)
                         .ThenInclude(a => a.Autor);

            var livroDto = query.Select(l => new LivroDto{
                Id = l.Id,
                Subtitulo = l.Subtitulo,
                QuantidadePagina = l.QuantidadePagina,
                AnoPublicacao = l.AnoPublicacao,
                Versao = l.Versao,
                Autores = l.LivrosAutores.Select(a => a.Autor).ToArray()
            }).AsNoTracking()
              .OrderBy(l => l.Id)
              .Where(l => l.Id == livroId);

            return await livroDto.FirstOrDefaultAsync();

        } 

        public async Task<LivroDto> GetLivroDtoByAutorIdAsync(int autorId)
        {
            IQueryable<Livro> query = _context.Livros;

            query = query.Include(la => la.LivrosAutores)
                         .ThenInclude(a => a.Autor);

            var livroDto = query.Select(l => new LivroDto{
                Id = l.Id,
                Subtitulo = l.Subtitulo,
                QuantidadePagina = l.QuantidadePagina,
                AnoPublicacao = l.AnoPublicacao,
                Versao = l.Versao,
                Autores = l.LivrosAutores.Select(a => a.Autor).ToArray()
            }).AsNoTracking()
              .OrderBy(l => l.Id)
              .Where(a => a.Autores.Any(au => au.Id == autorId));

            return await livroDto.FirstOrDefaultAsync();

        }        
        
        public async Task<Autor[]> GetAllAutoresAsync()
        {
            IQueryable<Autor> query = _context.Autores;

            query = query.Include(la => la.LivrosAutores)
                         .ThenInclude(l => l.Livro);

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.ToArrayAsync();

        }     

        public async Task<AutorDto[]> GetAllAutoresDtoAsync()
        {
            IQueryable<Autor> query = _context.Autores;

            query = query.Include(la => la.LivrosAutores)
                         .ThenInclude(l => l.Livro);

            var autoresDto = query.Select(a => new AutorDto{
                Id = a.Id,
                Nome = a.Nome,
                SobreNome = a.SobreNome,
                Pais = a.Pais,
                Livros = a.LivrosAutores.Select(l => l.Livro).ToArray()
            }).AsNoTracking()
              .OrderBy(a => a.Id);

            return await autoresDto.ToArrayAsync();;

        }    

        public async Task<Autor> GetAutorByIdAsync(int autorId)
        {
            IQueryable<Autor> query = _context.Autores;
            
            query = query.Include(la => la.LivrosAutores)
                         .ThenInclude(l => l.Livro);

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a=> a.Id == autorId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<AutorDto> GetAutorDtoByIdAsync(int autorId)
        {
            IQueryable<Autor> query = _context.Autores;
            query = query.Include(la => la.LivrosAutores)
                         .ThenInclude(l => l.Livro);

            var autorDto = query.Select(a => new AutorDto{
                Id = a.Id,
                Nome = a.Nome,
                SobreNome = a.SobreNome,
                Pais = a.Pais,
                Livros = a.LivrosAutores.Select(l => l.Livro).ToArray()
            }).AsNoTracking()
              .OrderBy(a => a.Id)  
              .Where(a => a.Id == autorId);

            return await autorDto.FirstOrDefaultAsync();
        }        

        public Task<Autor[]> GetAutoresBylivroId(int livroId)
        {
            throw new System.NotImplementedException();
        }


    }
}