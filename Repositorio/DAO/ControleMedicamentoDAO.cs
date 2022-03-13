using NHibernate;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 15/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class ControleMedicamentoDAO : RepositorioCrudDao<ControleMedicamento>
    {
        public static bool Salvar(ControleMedicamento ControleMedicamento)
        {
            var salvou = new ControleMedicamentoDAO().SalvarOuAtualizar(ControleMedicamento);
            return salvou;
        }
              

        public static string Apagar(ControleMedicamento ControleMedicamento)
            => new ControleMedicamentoDAO().Excluir(ControleMedicamento);

        public static List<ControleMedicamento> GetTodosRegistros(int entidadeId)
            => new ControleMedicamentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static List<ControleMedicamento> GetControlesMedicamentoDiaEspecifico(DateTime data, int entidadeId)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var dados = from a in Session.Query<ControleMedicamento>()
                                    where a.DataExecucao.Date == data.Date && a.Entidade.Id == entidadeId
                                    select a;
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

        //=> new ControleMedicamentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static ControleMedicamento GetById(int ControleMedicamentoId)
            => new ControleMedicamentoDAO().GetPorId(ControleMedicamentoId);

    }
}
