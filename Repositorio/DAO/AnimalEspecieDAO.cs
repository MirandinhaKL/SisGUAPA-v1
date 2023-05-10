using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.DAO
{
    public class AnimalEspecieDAO : RepositorioCrudDao<AnimalEspecie>
    {
        public static List<AnimalEspecie> GetTodosRegistros(int entidadeId)
        {
            return new AnimalEspecieDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList(); 
        }
    }
}
