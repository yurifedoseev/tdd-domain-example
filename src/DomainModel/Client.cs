namespace Crm
{
    using System;

    public class Client
    {
        public Client(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            Name = name;
        }

        public string Name { get; set; }

        internal Manager Manager { get; set; }

        internal void ClearManager()
        {
            Manager = null;
        }

        internal void SetManager(Manager manager)
        {
            Manager = manager;
        }

        internal void TransferTo(Manager targetManager)
        {
            Manager.TransferClientTo(this, targetManager);
        }
    }
}