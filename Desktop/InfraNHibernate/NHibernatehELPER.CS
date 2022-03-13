using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.InfraNHibernate
{
    public class NHibernateHelper
    {
        /*
       * Com o ISessionFactory, podemos construir uma instância de
       * ISession utilizando o método OpenSession
       */
        private static ISessionFactory fabrica = CriaSessionFactory();

        /// <summary>
        /// Instâncias de ISession são contruídas por uma fábrica
        /// conhecida como NHibernate.ISessionFactory.
        /// Conseguimos uma instância dessa fábrica utilizando o método
        /// BuildSessionFactory da classe Configuration do NHibernate
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory CriaSessionFactory()
        {
            Configuration cfg = RecuperaConfiguracao();
            return cfg.BuildSessionFactory();
        }

        /// <summary>
        /// Devolve uma instância de Configuration com os mapeamentos adicionados:
        /// </summary>
        /// <returns></returns>
        public static Configuration RecuperaConfiguracao()
        {
            // Encontra os arquivos de mapeamento e configuração do NHibernate, parseá-los e nos fornecer os
            // mecanismos necessários para o acesso aos dados. 
            Configuration cfg = new Configuration();

            // O Configure() busca hibernate.cfg.xml, para fazer a configuração do NHibernate. 
            cfg.Configure();

            // Essa linha faz com que o NHibernate procure todos os arquivos hbm.xml do assembly atual e 
            // adicione as entidades mapeadas à configuração.
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }

        /// <summary>
        /// Cria as tabelas no banco de dados.
        /// </summary>
        public static void GeraSchema()
        {
            Configuration cfg = RecuperaConfiguracao();

            // Através da classe NHibernate.Tool.hbm2ddl.SchemaExport, criará as tabelas do banco de dados.
            new NHibernate.Tool.hbm2ddl.SchemaExport(cfg).Create(true, true);
        }

        /// <summary>
        /// Abre a conexão (sessão) com o banco.
        /// </summary>
        public static ISession AbreSession()
        {
            return fabrica.OpenSession();
        }
    }
}

