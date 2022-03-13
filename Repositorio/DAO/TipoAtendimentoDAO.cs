using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 15/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class TipoAtendimentoDAO : RepositorioCrudDao<TipoAtendimento>
    {
        public static bool Salvar(TipoAtendimento tipoAtendimento)
              => new TipoAtendimentoDAO().SalvarOuAtualizar(tipoAtendimento);

        public static string Apagar(TipoAtendimento tipoAtendimento)
            => new TipoAtendimentoDAO().Excluir(tipoAtendimento);

        public static List<TipoAtendimento> GetTodosRegistros(int entidadeId)
            => new TipoAtendimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static TipoAtendimento GetById(int tipoAtendimentoId)
            => new TipoAtendimentoDAO().GetPorId(tipoAtendimentoId);
    }
}
