using System.Text.Json.Serialization;

namespace AdaTech.WebAPI.Imoveis.Models
{
    public class Endereco : IEntityWithId
    {
        public Endereco() { }

        public Endereco(string logradouro, string bairro, string cidade, string estado, string cep, int id = -1)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Id = id;

        }

        [JsonIgnore]

        public int Id { get; set; }


        [JsonPropertyName("cep")]
        public string? Cep { get; set; }

        [JsonPropertyName("state")]
        public string? Estado { get; set; }

        [JsonPropertyName("city")]
        public string? Cidade { get; set; }

        [JsonPropertyName("neighborhood")]
        public string? Bairro { get; set; }

        [JsonPropertyName("street")]
        public string? Logradouro { get; set; }


        [JsonIgnore]
        public int ImovelId { get; set; }
    }
}
