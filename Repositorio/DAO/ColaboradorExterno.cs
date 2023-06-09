using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 12/11/2020
* Última alteração em: 07/06/23
*/

namespace Repositorio.Classes
{
    public class ColaboradorExternoDAO : RepositorioCrudDao<ColaboradorExterno>
    {
        public static string Apagar(ColaboradorExterno colaborador)
            => new ColaboradorExternoDAO().Excluir(colaborador);

        public static List<ColaboradorExterno> GetTodosRegistros(int entidadeId)
            => new ColaboradorExternoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

   
    }
}
