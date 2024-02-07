using AdaTech.WebAPI.Imoveis.Models;

namespace AdaTech.WebAPI.Imoveis.Data
{
    public static class DataEntity
    {
        public static List<Imovel> Imoveis { get; set; } = new List<Imovel>
        {
            new Imovel(TipoImovel.Casa, 100000, 1),
            new Imovel(TipoImovel.Apartamento, 200000, 2),
            new Imovel(TipoImovel.Terreno, 50000, 3),
            new Imovel(TipoImovel.Comercial, 300000, 4),
            new Imovel(TipoImovel.Casa, 120000, 5),
            new Imovel(TipoImovel.Apartamento, 250000, 6),
            new Imovel(TipoImovel.Terreno, 60000, 7),
            new Imovel(TipoImovel.Comercial, 350000, 8),
            new Imovel(TipoImovel.Casa, 130000, 9),
            new Imovel(TipoImovel.Apartamento, 210000, 10),
            new Imovel(TipoImovel.Terreno, 70000, 11),
            new Imovel(TipoImovel.Comercial, 360000, 12),
            new Imovel(TipoImovel.Casa, 110000, 13),
            new Imovel(TipoImovel.Apartamento, 220000, 14),
            new Imovel(TipoImovel.Terreno, 80000, 15),
            new Imovel(TipoImovel.Comercial, 310000, 16),
            new Imovel(TipoImovel.Casa, 140000, 17),
            new Imovel(TipoImovel.Apartamento, 230000, 18),
            new Imovel(TipoImovel.Terreno, 90000, 19),
            new Imovel(TipoImovel.Comercial, 320000, 20),
            new Imovel(TipoImovel.Casa, 150000, 21),
            new Imovel(TipoImovel.Apartamento, 240000, 22),
            new Imovel(TipoImovel.Terreno, 100000, 23),
            new Imovel(TipoImovel.Comercial, 330000, 24)
        };

        public static List<Proprietario> Proprietarios { get; set; } = new List<Proprietario>
        {
            new Proprietario(1, "João", "12345678900", "123456789"),
            new Proprietario(2, "Maria", "98765432100", "987654321"),
            new Proprietario(3, "José", "12312312300", "123123123"),
            new Proprietario(4, "Ana", "45645645600", "456456456"),
            new Proprietario(5, "Carlos", "78978978900", "789789789"),
            new Proprietario(6, "Mariana", "32132132100", "321321321"),
            new Proprietario(7, "Pedro", "65465465400", "654654654"),
            new Proprietario(8, "Antônia", "98798798700", "987987987"),
            new Proprietario(9, "Paulo", "15915915900", "159159159"),
            new Proprietario(10, "Júlia", "35735735700", "357357357")
        };

        public static List<Endereco> Enderecos { get; set; } = new List<Endereco>
        {
            new Endereco("Rua 1", "Bairro 1", "Cidade 1", "Estado 1", "12345678", 1),
            new Endereco("Rua 2", "Bairro 2", "Cidade 2", "Estado 2", "87654321", 2),
            new Endereco("Rua 3", "Bairro 3", "Cidade 3", "Estado 3", "12312312", 3),
            new Endereco("Rua 4", "Bairro 4", "Cidade 4", "Estado 4", "45645645", 4),
            new Endereco("Rua 5", "Bairro 5", "Cidade 5", "Estado 5", "78978978", 5),
            new Endereco("Rua 6", "Bairro 6", "Cidade 6", "Estado 6", "32132132", 6),
        };
    }
}
