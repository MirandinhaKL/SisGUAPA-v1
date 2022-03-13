using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 12/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class ColaboradorExternoDAO : RepositorioCrudDao<ColaboradorExterno>
    {
        public static bool Salvar(ColaboradorExterno colaborador)
              => new ColaboradorExternoDAO().SalvarOuAtualizar(colaborador);

        public static string Apagar(ColaboradorExterno colaborador)
            => new ColaboradorExternoDAO().Excluir(colaborador);

        public static List<ColaboradorExterno> GetTodosRegistros(int entidadeId)
            => new ColaboradorExternoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static ColaboradorExterno GetById(int colaboradorId)
            => new ColaboradorExternoDAO().GetPorId(colaboradorId);
    }
}
