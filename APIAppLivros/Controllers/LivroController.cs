using APIAppLivros.Models;
using APIAppLivros.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAppLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        // GET: api/<LivroController>
        [HttpGet]
        public async Task<IEnumerable<Livro>> Get()
        {
            return await _livroRepository.ListarTodosDB();
        }

        // GET api/<LivroController>/5
        [HttpGet("{id}")]
        public async Task<Livro> Get(int id)
        {
            return await _livroRepository.BuscarPorIdDB(id);
        }

        // POST api/<LivroController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LivroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LivroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _livroRepository.DeletarPorid (id);

            return  Ok();
        }
    }
}
