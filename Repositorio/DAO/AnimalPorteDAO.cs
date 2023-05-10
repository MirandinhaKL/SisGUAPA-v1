using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.DAO
{
    public class AnimalPorteDAO : RepositorioCrudDao<AnimalPorte>
    {
        public static List<AnimalPorte> GetTodosRegistros(int entidadeId)
        {
            return new AnimalPorteDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }
    }
}
