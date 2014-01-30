namespace Crm.Commands
{
    using ByndyuSoft.Infrastructure.Domain.Commands;

    public class TransferClientToManager : ICommandContext
    {
        public int TargetManagerId { get; set; }
        public int ClientId { get; set; }
    }
}