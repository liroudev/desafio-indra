using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.API.Data;
using Livraria.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livraria.API.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private IRepository _repo{get;set;}

    public LivrosController(IRepository repo)
    {
        _repo = repo;
    }

        /// <summary>
        /// Recupera todos os livro com seus respectivos autores
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results =  await _repo.GetAllLivrosAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,"Server side internal error!");
            }
            
        }

        /// <summary>
        /// Recupera um livro pelo ID com seus respectivos autores
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _repo.GetLivroDtoByIdAsync(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Server side internal error!");
            }
             
        }

        // POST api/todo
        /// <summary>
        /// Cria um novo Livro relacionado com Autor
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     Copiar este modelo de Json ao Clicar no Try it out
        ///     {
        ///         "titulo": "string",
        ///         "subtitulo": "string",
        ///         "quantidadePagina": 0,
        ///         "anoPublicacao": 0,
        ///         "versao": "string",
        ///         "livrosAutores": [
        ///             {
        ///                 "autor": {
        ///                     "nome": "string",
        ///                     "sobreNome": "string",
        ///                     "pais": "string"
        ///                 }
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna o novo item criado</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Post(Livro model)
        {

            try
            {
                _repo.Add(model);

                if ( await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }

            }
            catch (System.Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,"Server side internal error!");
            }

            return BadRequest();
        }


        /// <summary>
        /// Atualiza apenas um livro
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     Copiar este modelo de Json para atualizar apenas o livro
        ///     {
        ///         "id": 5,   
        ///         "titulo": "Novo Titulo",
        ///         "subtitulo": "Novo Subtitulo",
        ///         "quantidadePagina": 25,
        ///         "anoPublicacao": 25,
        ///         "versao": "Nova Versao"
        ///     }
        ///
        /// </remarks>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Put(int id , Livro model)
        {
            
            try
            {
                var livro = await _repo.GetLivroByIdAsync(id);

                if(livro == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
                
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Server side internal error!");
            }

            return BadRequest();

        }

        // DELETE api/livro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var livro = await _repo.GetLivroByIdAsync(id);

                if(livro == null) return NotFound();

                _repo.Delete(livro);

                if( await _repo.SaveChangesAsync())
                {
                     return Ok();
                }

            }
            catch (System.Exception ex)
            {
                return BadRequest($"erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}
