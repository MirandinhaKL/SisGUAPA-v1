using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Criado em: 23/12/20
 */ 

namespace Repositorio.DAO
{
    public class MotivoFalecimentoDAO : RepositorioCrudDao<MotivoFalecimento>
    {
        public static int Salvar(MotivoFalecimento motivo)
        {
            return (int)new MotivoFalecimentoDAO().Inserir(motivo);
        }

        public static bool Atualizar(MotivoFalecimento motivo)
        {
            return new MotivoFalecimentoDAO().Alterar(motivo);
        }

        public static string Apagar(MotivoFalecimento motivo)
            => new MotivoFalecimentoDAO().Excluir(motivo);
        

        public static List<MotivoFalecimento> GetTodosRegistros(int entidadeId)
        {
            return new MotivoFalecimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }
    }
}
