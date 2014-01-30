namespace Crm
{
    using System;

    [Serializable]
    public class TransferOutsiteTheDepartmentException : Exception
    {
        public TransferOutsiteTheDepartmentException(Manager currentManager, Manager targetManager, Client client)
        {
            CurrentManager = currentManager;
            TargetManager = targetManager;
            Client = client;
        }

        public Manager CurrentManager { get; private set; }
        public Manager TargetManager { get; private set; }

        public Client Client { get; private set; }

        public override string Message
        {
            get
            {
                return string.Format("Попытка передать клиента {0} от менеджера {1} из отдела {2} к менеджеру {3} из отдела {4}",
                    Client.Name,
                    CurrentManager.Name,
                    CurrentManager.Department.Name,
                    TargetManager.Name,
                    TargetManager.Department.Name);
            }
        }
    }
}