using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 15/11/2020
* Última alteração em: 23/06/23
*/

namespace Repositorio.Classes
{
    public class PatologiaDAO : RepositorioCrudDao<Patologia>
    {
        public static List<Patologia> GetTodosRegistros(int entidadeId)
            => new PatologiaDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
    }
}
