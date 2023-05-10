using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 13/09/20
 * Atualizado em: 10/05/23
 */

namespace Repositorio.DAO
{
    public class MotivoRecolhimentoDAO : RepositorioCrudDao<MotivoRecolhimento>
    {
        public static List<MotivoRecolhimento> GetTodosRegistros(int entidadeId)
        {
            return new MotivoRecolhimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }
    }
}