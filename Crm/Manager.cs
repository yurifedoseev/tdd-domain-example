using System.Collections.Generic;

namespace Crm
{
    public class Manager
    {
        private readonly IList<Client> clients;
        
        public Manager(string name)
        {
            clients = new List<Client>();
            Name = name;
        }
        
        public string Name { get; private set; }

        public void AddClient(Client client)
        {
            client.Manager = this;
            clients.Add(client);
        }

        public IEnumerable<Client> GetClients()
        {
            return clients;
        }

        private void RemoveClient(Client client)
        {
            clients.Remove(client);
            client.Manager = null;
        }
        
        public void TransferClientTo(Client client, Manager targetManager)
        {
            if (client.Manager != this)
            {
                throw new TransferClientDeniedException(this, client);
            }
                
            this.RemoveClient(client);
            targetManager.AddClient(client);
        }
    }
}