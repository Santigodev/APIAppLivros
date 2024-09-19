using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAppLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        // GET: api/<LivrosController>
        [HttpGet]
        public IEnumerable<string> ListarTodos()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LivrosController>/5
        [HttpGet("{id}")]
        public string BuscarPorId(int id)
        {
            return "value";
        }

        // POST api/<LivrosController>
        [HttpPost]
        public void Criar([FromBody] string value)
        {
        }

        // PUT api/<LivrosController>/5
        [HttpPut("{id}")]
        public void Atualizar(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LivrosController>/5
        [HttpDelete("{id}")]
        public void Deletar(int id)
        {
        }
    }
}
