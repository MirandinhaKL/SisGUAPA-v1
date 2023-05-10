using NHibernate;
using Repositorio.Entidades;
using System.Collections.Generic;
using System.Linq;

/*
 * Alterado em: 04/05/23
 */
namespace Repositorio.DAO
{
    public class AnimalCorDAO : RepositorioCrudDao<AnimalCor>
    {
        public static List<AnimalCor> GetTodosRegistros(int entidadeId)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                return Session.Query<AnimalCor>().Where(k => k.Entidade.Id == entidadeId).ToList();
            }
        }
    }
}
