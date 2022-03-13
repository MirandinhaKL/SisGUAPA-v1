using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 15/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class PatologiaDAO : RepositorioCrudDao<Patologia>
    {
        public static bool Salvar(Patologia patologia)
              => new PatologiaDAO().SalvarOuAtualizar(patologia);

        public static string Apagar(Patologia patologia)
            => new PatologiaDAO().Excluir(patologia);

        public static List<Patologia> GetTodosRegistros(int entidadeId)
            => new PatologiaDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static Patologia GetById(int patologiaId)
            => new PatologiaDAO().GetPorId(patologiaId);
    }
}
