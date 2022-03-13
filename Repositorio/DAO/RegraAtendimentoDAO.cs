using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;
/*
 * Criado em: 26/10/21
 */
namespace Repositorio.DAO
{
    public class RegraAtendimentoDAO : RepositorioCrudDao<RegraAtendimento>
    {
        public static bool Salvar(RegraAtendimento regraAtendimento)
            => new RegraAtendimentoDAO().SalvarOuAtualizar(regraAtendimento);

        public static string Apagar(RegraAtendimento regraAtendimento)
            => new RegraAtendimentoDAO().Excluir(regraAtendimento);

      
        public static IList<RegraAtendimento> GetTodosRegistros(int entidadeId)
        {
            var atendimentos = new RegraAtendimentoDAO().Consultar(entidadeId).ToList();

            if (atendimentos != null && atendimentos.Count == 0)
            {
                var regras = MontarRegrasFixas();

                foreach (var item in regras)
                    Salvar(item);

                atendimentos = new RegraAtendimentoDAO().Consultar(entidadeId).ToList();
            }
          
            return atendimentos.ToList();
        }

        private static List<RegraAtendimento> MontarRegrasFixas() 
        {
            var regras = new List<RegraAtendimento>();

            var regra1 = new RegraAtendimento()
            {
                Procedimento = "antipulga",
                NumeroDias = 180
            };
            var regra2 = new RegraAtendimento()
            {
                Procedimento = "vermifugo",
                NumeroDias = 180
            };
            var regra3 = new RegraAtendimento()
            {
                Procedimento = "vacina",
                NumeroDias = 365
            };
            regras.Add(regra1);
            regras.Add(regra2);
            regras.Add(regra3);

            return regras;
        }

    }
}
