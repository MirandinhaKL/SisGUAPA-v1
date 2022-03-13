using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 08/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class EnderecoColaboradorExternoDAO : RepositorioCrudDao<EnderecoColaboradorExterno>
    {
        public static bool Salvar(EnderecoColaboradorExterno endereco)
              => new EnderecoColaboradorExternoDAO().SalvarOuAtualizar(endereco);

        public static string Apagar(EnderecoColaboradorExterno endereco)
            => new EnderecoColaboradorExternoDAO().Excluir(endereco);

        public static List<EnderecoColaboradorExterno> GetTodosRegistros(int entidadeId)
            => new EnderecoColaboradorExternoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static EnderecoColaboradorExterno GetById(int enderecoId)
            => new EnderecoColaboradorExternoDAO().GetPorId(enderecoId);
    }
}
