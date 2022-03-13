using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Criado em: 13/09/20
 */ 

namespace Repositorio.DAO
{
    public class MotivoRecolhimentoDAO : RepositorioCrudDao<MotivoRecolhimento>
    {
        public static int Salvar(MotivoRecolhimento motivo)
        {
            return (int) new MotivoRecolhimentoDAO().Inserir(motivo);
        }

        public static bool Atualizar(MotivoRecolhimento motivo)
        {
            return new MotivoRecolhimentoDAO().Alterar(motivo);
        }

        public static string Apagar(MotivoRecolhimento motivo)
           => new MotivoRecolhimentoDAO().Excluir(motivo);

        public static List<MotivoRecolhimento> GetTodosRegistros(int entidadeId)
        {
            return new MotivoRecolhimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }
    }
}
