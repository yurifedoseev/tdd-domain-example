namespace Crm
{
    using System;

    [Serializable]
    public class TransferClientDeniedException : Exception
    {
        public TransferClientDeniedException(Manager manager, Client client)
        {
            Manager = manager;
            Client = client;
        }

        public Manager Manager { get; private set; }

        public Client Client { get; private set; }

        public override string Message
        {
            get { return string.Format("Попытка передать клиента {0} от менеджера {1}, которому он не принадлежит", Client.Name, Manager.Name); }
        }
    }
}