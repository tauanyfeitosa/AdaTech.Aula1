using AdaTech.WebAPI.Imoveis.Data;
using AdaTech.WebAPI.Imoveis.Models;
using AdaTech.WebAPI.Imoveis.Views;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech.WebAPI.Imoveis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImovelController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Imovel> Get()
        {
            return DataEntity.Imoveis;
        }

        [HttpGet("byId")]
        public IActionResult Get(int id)
        {
            var imovel = DataEntity.Imoveis.FirstOrDefault(i => i.Id == id);

            if (imovel == null) return BadRequest("Imóvel não encontrado");

            return Ok(imovel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Imovel imovel)
        {
            EntityViews.AdicionarEntidade(imovel, DataEntity.Imoveis);
            return Ok($"Imóvel {imovel.Id} cadastrado com sucesso");
        }

        [HttpPut("atualizar")]
        public IActionResult Put(int id, [FromBody] Imovel updatedImovel)
        {
            var imovel = DataEntity.Imoveis.FirstOrDefault(i => i.Id == id);
            if (imovel == null) return NotFound("Imóvel não encontrado");

            EntityViews.AtualizarEntidade(imovel.Id, updatedImovel, DataEntity.Imoveis);

            return Ok($"Imóvel {imovel.Id} atualizado com sucesso.");
        }

        [HttpDelete("deletar")]
        public IActionResult Delete(int id)
        {
            var imovel = DataEntity.Imoveis.FirstOrDefault(i => i.Id == id);
            if (imovel == null) return NotFound("Imóvel não encontrado");

            DataEntity.Imoveis.Remove(imovel);
            return Ok($"Imóvel {id} removido com sucesso");
        }

        [HttpPatch("adicionar-proprietario-imovel")]

        public IActionResult PatchProprietario(int id, int idProprietario)
        {
            var proprietario = DataEntity.Proprietarios.FirstOrDefault(p => p.Id == idProprietario);
            var imovel = DataEntity.Imoveis.FirstOrDefault(i => i.Id == id);
            if (imovel == null) return NotFound("Imóvel não encontrado");
            if (proprietario == null) return NotFound("Proprietário não encontrado");

            EntityViews.AdicionarProprietario(proprietario, imovel, DataEntity.Imoveis);
            EntityViews.AdicionarImovelProprietario(imovel, proprietario);

            return Ok($"Proprietário {proprietario.Id} - {proprietario.Nome} adicionado ao imóvel {imovel.Id}");
        }

        [HttpPatch("adicionar-endereco-imovel")]

        public IActionResult PatchEndereco(int id, int endereco)
        {
            var enderecoImovel = DataEntity.Enderecos.FirstOrDefault(e => e.Id == endereco);
            var imovel = DataEntity.Imoveis.FirstOrDefault(i => i.Id == id);

            if (imovel == null) return NotFound("Imóvel não encontrado");
            if (enderecoImovel == null) return NotFound("Endereço não encontrado");

            EntityViews.AdicionarEndereco(enderecoImovel, imovel, DataEntity.Imoveis);
            EntityViews.AdicionarImovelEndereco(imovel, enderecoImovel);

            return Ok($"Endereço {enderecoImovel.Id} adicionado ao imóvel {imovel.Id}");
        }
    }
}
