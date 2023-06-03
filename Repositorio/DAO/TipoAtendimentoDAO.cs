using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 15/11/2020
* Última alteração em: 31/05/23
*/

namespace Repositorio.Classes
{
    public class TipoAtendimentoDAO : RepositorioCrudDao<TipoAtendimento>
    {
        public static List<TipoAtendimento> GetTodosRegistros(int entidadeId)
            => new TipoAtendimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
    }
}