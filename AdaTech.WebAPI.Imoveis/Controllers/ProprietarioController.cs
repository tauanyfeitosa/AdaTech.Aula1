using AdaTech.WebAPI.Imoveis.Data;
using AdaTech.WebAPI.Imoveis.Models;
using AdaTech.WebAPI.Imoveis.Views;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech.WebAPI.Imoveis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Proprietario> Get()
        {
            return DataEntity.Proprietarios;
        }

        [HttpGet("byId")]
        public IActionResult Get(int id)
        {
            var proprietario = DataEntity.Proprietarios.FirstOrDefault(p => p.Id == id);
            if (proprietario == null) return BadRequest("Proprietário não encontrado");

            return Ok(proprietario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Proprietario proprietario)
        {
            EntityViews.AdicionarEntidade(proprietario, DataEntity.Proprietarios);

            return Ok($"O proprietário {proprietario.Id} - {proprietario.Nome} foi adicionado com sucesso!");
        }

        [HttpPut("atualizar-proprietario")]
        public IActionResult Put(int id, [FromBody] Proprietario updateProprietario)
        {
            var proprietario = DataEntity.Proprietarios.FirstOrDefault(p => p.Id == id);

            if (proprietario == null) return BadRequest("Proprietário não encontrado");

            EntityViews.AtualizarEntidade(id, updateProprietario, DataEntity.Proprietarios);

            return Ok($"O proprietário {proprietario.Id} - {proprietario.Nome} foi atualizado com sucesso!");
        }

        [HttpDelete("deletar-proprietario")]
        public IActionResult Delete(int id)
        {
            var proprietario = DataEntity.Proprietarios.FirstOrDefault(p => p.Id == id);
            if (proprietario == null) return BadRequest("Proprietário não encontrado");

            DataEntity.Proprietarios.Remove(proprietario);
            return Ok($"O proprietário {proprietario.Id} - {proprietario.Nome} foi removido com sucesso");
        }
    }
}
