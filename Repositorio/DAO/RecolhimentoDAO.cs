using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Criado em: 28/05/21
 */ 

namespace Repositorio.DAO
{
    public class RecolhimentoDAO : RepositorioCrudDao<Recolhimento>
    {
        public static int Salvar(Recolhimento recolhimento)
        {
            return (int) new RecolhimentoDAO().Inserir(recolhimento);
        }

        public static bool Atualizar(Recolhimento recolhimento)
        {
            return new RecolhimentoDAO().Alterar(recolhimento);
        }

        public static string Apagar(Recolhimento recolhimento)
        {
            return new RecolhimentoDAO().Excluir(recolhimento);
        }

        public static List<Recolhimento> GetTodosRegistros(int entidadeId)
        {
            return new RecolhimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();
        }

        public static Recolhimento GetById(int recolhimentoId)
        {
            return new RecolhimentoDAO().GetPorId(recolhimentoId);
        }

    }
}
