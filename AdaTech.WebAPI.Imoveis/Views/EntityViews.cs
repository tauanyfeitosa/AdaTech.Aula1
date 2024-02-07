using AdaTech.WebAPI.Imoveis.Models;

namespace AdaTech.WebAPI.Imoveis.Views
{
    public static class EntityViews
    {

        private static int GerarId<T>(List<T> entidades) where T : IEntityWithId
        {
            if (entidades.Count == 0)
            {
                return 1;
            }
            else
            {
                return entidades.Max(e => e.Id) + 1;
            }
        }

        public static void AdicionarEntidade<T>(T entidade, List<T> entidades) where T : IEntityWithId
        {
            entidade.Id = GerarId(entidades);
            entidades.Add(entidade);
        }

        public static void AtualizarEntidade<T>(int id, T novaEntidade, List<T> entidades) where T : IEntityWithId
        {
            var index = entidades.FindIndex(e => e.Id == id);
            if (index != -1)
            {
                novaEntidade.Id = id;
                entidades[index] = novaEntidade;
            }
        }

        public static void AdicionarProprietario(Proprietario proprietario, Imovel imovel, List<Imovel> imoveis)
        {
            imovel.ProprietarioId = proprietario.Id;

            AtualizarEntidade(imovel.Id, imovel, imoveis);
        }

        public static void AdicionarImovelProprietario(Imovel imovel, Proprietario proprietario)
        {
            proprietario.Imoveis.Add(imovel);
        }

        public static void AdicionarEndereco(Endereco endereco, Imovel imovel, List<Imovel> imoveis)
        {
            imovel.EnderecoId = endereco.Id;

            AtualizarEntidade(imovel.Id, imovel, imoveis);
        }

        public static void AdicionarImovelEndereco(Imovel imovel, Endereco endereco)
        {
            endereco.ImovelId = imovel.Id;
        }
    }
}
