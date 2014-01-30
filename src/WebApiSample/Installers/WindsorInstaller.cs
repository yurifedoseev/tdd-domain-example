namespace WebApiSample.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Crm;
    using Infrastructure.MyFavoriteOrm;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMailService>().ImplementedBy<SuperMailService>());
        }
    }
}