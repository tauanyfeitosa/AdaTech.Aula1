using System.Text.Json.Serialization;

namespace AdaTech.WebAPI.Imoveis.Models
{
    public class Imovel : IEntityWithId
    {
        public Imovel() { }

        public Imovel(TipoImovel tipo, double valor, int id = -1, Proprietario? proprietario = null)
        {
            Id = id;
            Tipo = tipo;
            Valor = valor;
            ProprietarioId = proprietario?.Id ?? -1;
        }

        [JsonIgnore]
        public int Id { get; set; }
        public TipoImovel Tipo { get; set; }
        public double Valor { get; set; }

        [JsonIgnore]
        public Endereco? Endereco { get; set; }
        public int EnderecoId { get; set; }

        [JsonIgnore]
        public int ProprietarioId { get; set; }
    }
}
