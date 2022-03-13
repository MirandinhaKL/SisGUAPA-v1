using NHibernate;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;

/*
* Criado em: 18/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class PreAtendimentoDAO : RepositorioCrudDao<PreAtendimento>
    {
        public static bool Salvar(PreAtendimento preAtendimento)
              => new PreAtendimentoDAO().SalvarOuAtualizar(preAtendimento);

        public static string Apagar(PreAtendimento preAtendimento)
            => new PreAtendimentoDAO().Excluir(preAtendimento);

        public static List<PreAtendimento> GetTodosRegistros(int entidadeId)
            => new PreAtendimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static PreAtendimento GetById(int preAtendimentoId)
            => new PreAtendimentoDAO().GetPorId(preAtendimentoId);

        public static List<PreAtendimento> GetPreAtendimentoDiaEspecifico(DateTime data, int entidadeId)
        {
            using (NHibernate.ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var dados = from p in Session.Query<PreAtendimento>()
                                    where p.DataPreAtendimento == data.Date && p.Entidade.Id == entidadeId
                                    select p;
                        Transaction.Commit();
                        return dados.ToList();
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                        {
                            Transaction.Rollback();
                            return null;
                        }
                        Console.WriteLine(exception.Message);
                        throw new Exception("Erro ao inserir entidade: " + exception.Message);
                    }
                }
            }
        }
    }
}
