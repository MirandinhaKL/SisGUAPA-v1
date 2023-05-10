using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
 * Criado em: 23/12/20
 * Atualizado em: 10/05/23
 */

namespace Repositorio.DAO
{
    public class MotivoFalecimentoDAO : RepositorioCrudDao<MotivoFalecimento>
    {
        public static List<MotivoFalecimento> GetTodosRegistros(int entidadeId)
        {
            return new MotivoFalecimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }
    }
}