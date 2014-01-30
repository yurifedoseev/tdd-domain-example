namespace WebApiSample.Installers
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Infrastructure.MyFavoriteOrm;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class CommandInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            BasedOnDescriptor commands = AllTypes.FromAssemblyContaining(typeof (TransferClientToManagerCommand))
                .BasedOn(typeof (ICommand<>))
                .WithService.AllInterfaces()
                .Configure(c => c.LifeStyle.Transient);

            container.Register(
                commands,
                Component.For<ICommandBuilder>().ImplementedBy(typeof (CommandBuilder)),
                Component.For<ICommandFactory>().AsFactory().LifeStyle.Transient
                );
        }
    }
}