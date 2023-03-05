using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Middlewares.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        // GET: api/<PessoaController>
        [HttpGet]
        public IActionResult Get([FromQuery]string nome, [FromQuery]string cidade)
        {
            if (String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(cidade))
                return BadRequest();

            return  Ok($"Você buscou por alunos com o nome {nome} na cidade {cidade}");
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest();

            return Ok($"Aluno {id}");
        }

        // POST api/<PessoaController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Criou {value}");
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok($"Alterou item {id} para valor {value}");
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            return Ok($"Deletou valor com id {id}");
        }
    }
}
