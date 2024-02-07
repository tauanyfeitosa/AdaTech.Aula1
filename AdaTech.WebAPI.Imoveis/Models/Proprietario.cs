using System.Text.Json.Serialization;

namespace AdaTech.WebAPI.Imoveis.Models
{
    public class Proprietario : IEntityWithId
    {
        public Proprietario() { }

        public Proprietario(int id, string nome, string cpf, string telefone)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
        }

        [JsonIgnore]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }

        [JsonIgnore]
        public ICollection<Imovel>? Imoveis { get; set; } = new List<Imovel>();
    }
}
