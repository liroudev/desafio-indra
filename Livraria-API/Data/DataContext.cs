using Livraria.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Livraria.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroAutor>()
                .HasKey(la=> new {la.LivroId, la.AutorId});       

            modelBuilder.Entity<LivroAutor>()
                .HasOne(l => l.Livro)
                .WithMany(la =>la.LivrosAutores)
                .HasForeignKey(l => l.LivroId);

            modelBuilder.Entity<LivroAutor>()
                .HasOne(a => a.Autor)
                .WithMany(la =>la.LivrosAutores)
                .HasForeignKey(a => a.AutorId);


            // modelBuilder.Entity<Livro>()
            //     .HasData(
            //         new Livro(1,"O Conto da Aia","Romance por Margaret Atwood",367,1985,"1º Versão - Internacional"),
            //         new Livro(2,"Kingsman: O Diamante Vermelho","Ficção de espionagem",147,2019,"Capa Dura"),
            //         new Livro(3,"Drácula","Um conto de terror",432,2019,"Luxo com broxura"),
            //         new Livro(4,"Código Da Vinci","Romance policial",432,2004,"Editora Arqueiro; 1º Versão"));

            // modelBuilder.Entity<Autor>()
            //     .HasData(
            //         new Autor(1,"Margaret","Autwood","Canadá"),
            //         new Autor(2,"Rob","Williams","Inglaterra"),
            //         new Autor(3,"Simon","Fraser","Inglaterra"),
            //         new Autor(4,"Bram","Stoker","Irlanda"),
            //         new Autor(5,"Dan","Brown","Estados Unidos"));

            // modelBuilder.Entity<LivroAutor>()
            //     .HasData(
            //         new LivroAutor(1,1),
            //         new LivroAutor(2,2),
            //         new LivroAutor(2,3),
            //         new LivroAutor(3,4),
            //         new LivroAutor(4,5));                    

        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<LivroAutor> LivrosAutores { get; set; }
    }
}