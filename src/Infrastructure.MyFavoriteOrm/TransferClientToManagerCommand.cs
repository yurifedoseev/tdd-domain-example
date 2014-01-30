namespace Infrastructure.MyFavoriteOrm
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Crm;
    using Crm.Commands;

    public class TransferClientToManagerCommand : ICommand<TransferClientToManager>
    {
        private readonly IMailService mailService;

        public TransferClientToManagerCommand(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public void Execute(TransferClientToManager commandContext)
        {
            // TODO: по данным из контекста берем из БД/сервиса/файловой системы/памяти менеджера, клиента и менеджера, которому переводим клиента

            // *** для примера просто создаем сущности, а не выбираем из хранилища
            var department = new Department("dep");
            var currentManager = new Manager("name", department, Position.Manager);
            var client = new Client("name");
            currentManager.AddClient(client);
            var targetManager = new Manager("name", department, Position.Manager);
            // *** выбрали всех из хранилища

            currentManager.TransferClientTo(client, targetManager);

            mailService.Send(currentManager);
        }
    }
}