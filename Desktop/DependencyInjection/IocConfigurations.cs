using Ninject.Modules;
using Repositorio.Interfaces;
using Repositorio.Servicos;

namespace Desktop.DependencyInjection
{
    internal class IocConfigurations : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmailService>().To<EmailService>().InSingletonScope();

            Bind<IEntidadeService>().To<EntidadeService>().InSingletonScope();
            Bind<IUsuarioService>().To<UsuarioService>().InSingletonScope();
            Bind<ITratamentoService>().To<TratamentoService>().InSingletonScope();
            Bind<IAtendimentoService>().To<AtendimentoService>().InSingletonScope();
            Bind<IMedicamentoService>().To<MedicamentoService>().InSingletonScope();
        }
    }
}