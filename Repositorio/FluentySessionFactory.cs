using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Repositorio
{
    public class FluentySessionFactory
    {
        //TODO: Utilizar uma interface para ambas bases
        private static string DadosDaConexao =
           "Server = localhost; " +
           "Database = sisguapa; " +
           "Uid = root; " +
           "Pwd = 21.root;";

        private static string DadosDaConexaoSQLite =
            @"Data Source=.\DBLocalSQLite.db;Pooling=true;FailIfMissing=false;Version=3";


        private static ISessionFactory Session;

        public static ISessionFactory CriarSession()
        {
            if (Session != null)
                return Session;

            //IPersistenceConfigurer ConfiguracaoDB = MySQLConfiguration.
            //                                        Standard.
            //                                        ConnectionString(DadosDaConexao).
            //                                        ShowSql();

            IPersistenceConfigurer ConfiguracaoDB = SQLiteConfiguration.
                                                    Standard.
                                                    InMemory().
                                                    ConnectionString(DadosDaConexaoSQLite).
                                                    ShowSql();

            var ConfiguracaoMapeamento = Fluently.
                Configure().
                Database(ConfiguracaoDB).
                Mappings(k => k.FluentMappings.AddFromAssemblyOf<Mapeamentos.EntidadeMap>()).
                Mappings(k => k.FluentMappings.AddFromAssemblyOf<Mapeamentos.UsuarioMap>()).
                ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, true));

            Session = ConfiguracaoMapeamento.BuildSessionFactory();
            return Session;
        }

        public static ISession AbrirSession()
        {
            return CriarSession().OpenSession();
        }
    }
}
