using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public class RepositorioCrudDao<T> : ICrudDao<T> where T : class
    {
        public enum EnumStatusDaAcao
        {
            FALHA = -1,
            OK = 0,
        }

        public bool Alterar(T classe)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        Session.Update(classe); ;
                        Transaction.Commit();
                        return true;
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                        {
                            Transaction.Rollback();
                            return false;
                        }
                        throw new Exception("Erro ao alterar: " + exception.Message);
                    }
                }
            }
        }
        //TODO: Ver como usar o id da Entidade de forma genérica.
        /// <summary>
        /// Retorna todos os itens da tabela da instituição logada no sistema.
        /// </summary>
        /// <param name="EntidadeId">Id da ONG, Associação, etc. </param>
        /// <returns></returns>
        public IList<T> Consultar(int EntidadeId)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                return (from k in Session.Query<T>() select k).ToList();
            }
        }

        public string Excluir(T entidade)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        Session.Delete(entidade);
                        Transaction.Commit();
                        return string.Empty;
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                            Transaction.Rollback();

                        return exception.InnerException.Message;
                    }
                }
            }
        }

        public string ExcluirComQuery(string query, T entidade)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var comando = Session.CreateQuery($"delete from {entidade} {query}");
                        comando.ExecuteUpdate();
                        Transaction.Commit();
                        return string.Empty;
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                            Transaction.Rollback();

                        return exception.InnerException.Message;
                    }
                }
            }
        }
        public T GetPorId(int id)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                return Session.Get<T>(id);
            }
        }

        public T GetPorString(T filtro)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                return Session.Get<T>(filtro);
            }
        }

        public object Inserir(T entidade)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var id = Session.Save(entidade);
                        Transaction.Commit();
                        return id;
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                        {
                            var nomeArquivo = nameof(entidade);
                            var mensagemInterna = exception?.InnerException?.Message;
                            var mensagemErro = exception.Message + "\r\n" + mensagemInterna; ;
                            ClassesGerais.GeraLog.Log(mensagemErro, nomeArquivo);
                            Transaction.Rollback();
                        }
                        return (int)EnumStatusDaAcao.FALHA;
                    }
                }
            }
        }

        //https://stackoverflow.com/questions/6659398/fluent-nhibernate-where-clause
        /// <summary>
        /// Retorna dados de uma classe informando o nome da coluna e da condição where.
        /// </summary>
        /// <param name="classe"></param>
        /// <param name="colunaBanco"></param>
        /// <param name="filtroWhere"></param>
        /// <returns></returns>
        public object GetDadoComWhere(T classe, string colunaBanco, object filtroWhere)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var dados = Session.CreateCriteria<T>()
                            .Add(Restrictions.Eq(colunaBanco, filtroWhere))
                            .List<T>();
                        Transaction.Commit();
                        return dados;
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

        /// <summary>
        /// Salvar ou atualiza dados de uma entidade.
        /// </summary>
        /// <param name="entidade">Classe a ser salva</param>
        /// <returns></returns>
        public bool SalvarOuAtualizar(T entidade)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        Session.SaveOrUpdate(entidade);
                        Transaction.Commit();
                        return true;
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                        {
                            Transaction.Rollback();
                            return false;
                        }
                        Console.WriteLine(exception.Message);
                        throw new Exception("Erro ao inserir entidade: " + exception.Message);
                    }
                }
            }
        }
    }
}

//https://stackoverflow.com/questions/6085568/how-to-do-a-fluent-nhibernate-one-to-one-mapping
//https://github.com/nhibernate/fluent-nhibernate/wiki/Getting-started
