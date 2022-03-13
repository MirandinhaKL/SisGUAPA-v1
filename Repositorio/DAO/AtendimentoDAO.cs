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
    public class AtendimentoDAO : RepositorioCrudDao<Atendimento>
    {
        public static bool Salvar(Atendimento atendimento)
        {
            var salvou = new AtendimentoDAO().SalvarOuAtualizar(atendimento);
            return salvou;
        }
              

        public static string Apagar(Atendimento atendimento)
            => new AtendimentoDAO().Excluir(atendimento);

        public static List<Atendimento> GetTodosRegistros(int entidadeId)
            => new AtendimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static Atendimento GetById(int atendimentoId)
            => new AtendimentoDAO().GetPorId(atendimentoId);

        public static List<Atendimento> GetAtendimentoDiaEspecifico(DateTime data, int entidadeId)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var dados = from a in Session.Query<Atendimento>()
                                    where a.DataAtendimentoInicio.Date == data.Date && a.Entidade.Id == entidadeId
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

        public static List<Atendimento> GetAtendimentoComTratamento(int entidadeId)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var dados = from a in Session.Query<Atendimento>()
                                    where a.Tratamento != null && a.Tratamento.EnumStatusTratamento != 0 && a.Entidade.Id == entidadeId
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

        public static List<Atendimento> GetTratamentos(int entidadeId)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var naoIniciado = 1;
                        var atendimentoRealizado = 0;

                        var atendimentos = (from a in Session.Query<Atendimento>()
                                            where a.Tratamento.EnumStatusTratamento != 0
                                            select a).ToList() ;

                        Transaction.Commit();

                        return atendimentos;
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
