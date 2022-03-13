using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 01/11/21
 */

namespace Repositorio.DAO
{
    public class EnderecoEntidadeDAO : RepositorioCrudDao<EnderecoEntidade>
    {
        public static bool Salvar(EnderecoEntidade endereco)
               => new EnderecoEntidadeDAO().SalvarOuAtualizar(endereco);

        public static string Apagar(EnderecoEntidade endereco)
            => new EnderecoEntidadeDAO().Excluir(endereco);

        public static List<EnderecoEntidade> GetTodosRegistros(int entidadeId)
            => new EnderecoEntidadeDAO().Consultar(entidadeId).Where(k => k.Id == entidadeId).ToList();

        public static EnderecoEntidade GetById(int enderecoId)
            => new EnderecoEntidadeDAO().GetPorId(enderecoId);
    }
}
