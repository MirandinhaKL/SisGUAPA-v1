using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 08/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class LarTemporarioDAO : RepositorioCrudDao<LarTemporario>
    {
        public static bool Salvar(LarTemporario lar)
              => new LarTemporarioDAO().SalvarOuAtualizar(lar);

        public static string Apagar(LarTemporario lar)
            => new LarTemporarioDAO().Excluir(lar);

        public static List<LarTemporario> GetTodosRegistros(int entidadeId)
            => new LarTemporarioDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static LarTemporario GetById(int larId)
            => new LarTemporarioDAO().GetPorId(larId);
    }
}
