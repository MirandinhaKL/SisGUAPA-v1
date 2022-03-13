using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 24/09/21
 */
namespace Repositorio.DAO
{
    public class EnderecoAdotanteDAO : RepositorioCrudDao<EnderecoAdotante>
    {
        public static int Salvar(EnderecoAdotante endereco)
        {
            return (int) new EnderecoAdotanteDAO().Inserir(endereco);
        }

        public static bool Atualizar(EnderecoAdotante endereco)
        {
            return new EnderecoAdotanteDAO().Alterar(endereco);
        }

        public static string Apagar(EnderecoAdotante endereco)
            => new EnderecoAdotanteDAO().Excluir(endereco);

        public static List<EnderecoAdotante> GetTodosRegistros(int entidadeId)
        {
            return new EnderecoAdotanteDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }

        public static EnderecoAdotante GetById(int enderecoId)
        {
            return new EnderecoAdotanteDAO().GetPorId(enderecoId);
        }
    }
}
