using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Crm
{
    [TestFixture]
    public class ClientTransferTest
    {
        private Client client;
        private Manager firstManager;
        private Manager targetManager;

        [SetUp]
        public void SetUp()
        {
            client = new Client { Name = "ООО Вектор Плюс" };
            
            firstManager = new Manager("Петров");
            targetManager = new Manager("Сидоров");
        }

        [Test]
        public void should_transfer_client_from_one_manager_to_another()
        {
            firstManager.AddClient(client);

            firstManager.TransferClientTo(client, targetManager);
            
            firstManager.GetClients().Should().BeEmpty();
            targetManager.GetClients().ShouldAllBeEquivalentTo(new List<Client> {client});
        }

        [Test]
        public void cant_transfer_client_wich_dont_belong_to_manager()
        {
            firstManager.Invoking(m => m.TransferClientTo(client, targetManager))
                .ShouldThrow<TransferClientDeniedException>();
        }
    }
}