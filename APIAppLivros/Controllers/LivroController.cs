using APIAppLivros.Models;
using APIAppLivros.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

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
        public async Task<IActionResult> Post([FromBody] Livro dados)
        {
            await _livroRepository.SalvarDB(dados);

            return Created("", dados);
        }

        // PUT api/<LivroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Livro dados)
        {
            dados.Id = id;
            await _livroRepository.AtualizarDB(dados);

            return Ok();
        }

        // DELETE api/<LivroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _livroRepository.DeletarPoridDB (id);

            return  Ok();
        }
    }
}
