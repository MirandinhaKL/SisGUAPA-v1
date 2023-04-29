using NHibernate;
using NHibernate.Criterion;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Classes
{
    public class EntidadeDAO : RepositorioCrudDao<Entidade>
    {
        public static bool Salvar(Entidade entidade)
            => new EntidadeDAO().SalvarOuAtualizar(entidade);

        public static string Apagar(Entidade entidade)
            => new EntidadeDAO().Excluir(entidade);

        public static Entidade GetEntidade(int entidadeId)
        {
            var entidades = new EntidadeDAO().Consultar(entidadeId).ToList();
            var usuariosInstituicao = entidades?.Where(k => k.Id == entidadeId);
            return usuariosInstituicao.FirstOrDefault();
        }

        public bool EntidadeExiste(string email)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        IList<Entidade> dados = Session.CreateCriteria<Entidade>()
                            .Add(Restrictions.Eq("Email", email))
                            .List<Entidade>();
                        
                        Transaction.Commit();

                        if (dados is null || !dados.Any())
                            return false;
                        else
                            return true;
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                        {
                            Transaction.Rollback();
                        }
                        Console.WriteLine(exception.Message);
                        throw new Exception("Erro ao obter os dados entidade: " + exception.Message);
                    }
                }
            }
         
        }
    }
}