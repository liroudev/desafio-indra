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
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private IRepository _repo {get;set;}

        public AutorController(IRepository repo)
        {
            _repo = repo;
        }

        // POST api/todo
        /// <summary>
        /// Recupera todos os Autores e seus respectivos livros
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results =  await _repo.GetAllAutoresDtoAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,"Server side internal error!");
            }
            
        }

        // POST api/todo
        /// <summary>
        /// Recupera um Autor e seus respectivos livros
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _repo.GetAutorDtoByIdAsync(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Server side internal error!");
            }        
        }

        // POST api/todo
        /// <summary>
        /// Inseri um novo Autor
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     Copiar este modelo de Json ao Clicar no Try it out
        ///     {
        ///         "nome": "Nome Atualizado",
        ///         "sobreNome": "Sobre Nome Atualizado",
        ///         "pais": "Bélgica",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna o novo item criado</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]        
        public async Task<IActionResult> Post(Autor model)
        {

            try
            {
                _repo.Add(model);

                if ( await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }

            }
            catch (System.Exception ex)
            {
                
                return BadRequest($"erro: {ex.Message}");
            }

            return BadRequest();
        }        

        // POST api/todo
        /// <summary>
        /// Atualiza o Autor
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     Copiar este modelo de Json ao Clicar no Try it out
        ///     {
        ///         "id": 1
        ///         "nome": "Nome Atualizado",
        ///         "sobreNome": "Sobre Nome Atualizado",
        ///         "pais": "Bélgica",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna o novo item criado</response>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]        
        public async Task<IActionResult> Put(int id, Autor model)
        {
            try
            {
                var autor = await _repo.GetAutorDtoByIdAsync(id);
                if (autor == null) return BadRequest();
                
                _repo.Update(model);

                if( await _repo.SaveChangesAsync())
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


         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var autor = await _repo.GetAutorByIdAsync(id);

                if(autor == null) return NotFound();

                _repo.Delete(autor);

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