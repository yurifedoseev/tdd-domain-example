using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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
        private Department salesDepartment;

        [SetUp]
        public void SetUp()
        {
            salesDepartment = new Department("Отдел продаж");
            client = new Client { Name = "ООО Вектор Плюс" };

            firstManager = new Manager("Петров", salesDepartment, Position.Manager);
            targetManager = new Manager("Сидоров", salesDepartment, Position.Manager);
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
        public void cant_transfer_client_which_doesnt_belong_to_manager()
        {
            firstManager.Invoking(m => m.TransferClientTo(client, targetManager))
                .ShouldThrow<TransferClientDeniedException>();
        }

        [Test]
        public void boss_of_manager_can_transfer_his_client()
        {
            var chief = new Manager("Иванов", salesDepartment, Position.DepartmentChief);

            chief.TransferClientTo(client, targetManager);

            firstManager.GetClients().Should().BeEmpty();
            targetManager.GetClients().ShouldAllBeEquivalentTo(new List<Client> { client });
        }
    }
}