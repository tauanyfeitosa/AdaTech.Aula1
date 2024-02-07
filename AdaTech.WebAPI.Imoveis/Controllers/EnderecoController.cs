using AdaTech.WebAPI.Imoveis.Data;
using AdaTech.WebAPI.Imoveis.Models;
using AdaTech.WebAPI.Imoveis.Views;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdaTech.WebAPI.Imoveis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //fazer validações com nullorwhitespace
    public class EnderecoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Endereco> Get()
        {
            return DataEntity.Enderecos;
        }

        [HttpGet("byId")]
        public IActionResult Get(int id)
        {
            var endereco = DataEntity.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null) return BadRequest("Endereço não encontrado");

            return Ok(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string cep)
        {
            var url = $"https://brasilapi.com.br/api/cep/v1/{cep}";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var endereco = JsonSerializer.Deserialize<Endereco>(content);

                        EntityViews.AdicionarEntidade(endereco, DataEntity.Enderecos);

                        return Created($"api/endereco/{endereco.Id}", endereco);
                    }
                    else
                    {
                        return BadRequest("CEP não encontrado");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Ocorreu um erro ao processar sua solicitação: " + ex.Message);
                }
            }
        }

        [HttpPut("byId")]
        public IActionResult Put(int id, [FromBody] Endereco updateEndereco)
        {
            var endereco = DataEntity.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null) return BadRequest("Endereço não encontrado");

            EntityViews.AtualizarEntidade(endereco.Id, updateEndereco, DataEntity.Enderecos);

            return Ok($"Endereço {endereco.Id} atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var endereco = DataEntity.Enderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null) return BadRequest("Endereço não encontrado");

            DataEntity.Enderecos.Remove(endereco);
            return Ok($"Endereço {id} removido com sucesso");
        }
    }
}

