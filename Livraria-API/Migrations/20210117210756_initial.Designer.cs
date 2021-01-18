﻿// <auto-generated />
using Livraria.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Livraria_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210117210756_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Livraria.API.Model.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Pais")
                        .HasColumnType("text");

                    b.Property<string>("SobreNome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Livraria.API.Model.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AnoPublicacao")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadePagina")
                        .HasColumnType("integer");

                    b.Property<string>("Subtitulo")
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .HasColumnType("text");

                    b.Property<string>("Versao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("Livraria.API.Model.LivroAutor", b =>
                {
                    b.Property<int>("LivroId")
                        .HasColumnType("integer");

                    b.Property<int>("AutorId")
                        .HasColumnType("integer");

                    b.HasKey("LivroId", "AutorId");

                    b.HasIndex("AutorId");

                    b.ToTable("LivrosAutores");
                });

            modelBuilder.Entity("Livraria.API.Model.LivroAutor", b =>
                {
                    b.HasOne("Livraria.API.Model.Autor", "Autor")
                        .WithMany("LivrosAutores")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livraria.API.Model.Livro", "Livro")
                        .WithMany("LivrosAutores")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
