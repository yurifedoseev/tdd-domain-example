namespace DomainModel.Tests
{
    using System.Collections.Generic;
    using Crm;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class ClientTransferTest
    {
        [SetUp]
        public void SetUp()
        {
            salesDepartment = new Department("Отдел продаж");
            supportDepartment = new Department("Поддержка");

            firstManager = new Manager("Петров", salesDepartment, Position.Manager);
            client = new Client("ООО Вектор Плюс");
            firstManager.AddClient(client);

            targetManager = new Manager("Сидоров", salesDepartment, Position.Manager);
        }

        private Client client;
        private Manager firstManager;
        private Manager targetManager;
        private Department salesDepartment;
        private Department supportDepartment;

        [Test]
        public void cant_transfer_client_which_doesnt_belong_to_manager()
        {
            var anotherManager = new Manager("Новиков", salesDepartment, Position.Manager);

            anotherManager
                .Invoking(m => m.TransferClientTo(client, targetManager))
                .ShouldThrow<TransferClientDeniedException>();
        }
        
        [Test]
        public void chief_of_manager_can_transfer_his_client()
        {
            var chief = new Manager("Иванов", salesDepartment, Position.DepartmentChief);

            chief.TransferClientTo(client, targetManager);

            firstManager.GetClients().Should().BeEmpty();
            targetManager.GetClients().ShouldAllBeEquivalentTo(new List<Client> {client});
        }

        [Test]
        public void should_transfer_client_from_one_manager_to_another()
        {
            firstManager.TransferClientTo(client, targetManager);

            firstManager.GetClients().Should().BeEmpty();
            targetManager.GetClients().ShouldAllBeEquivalentTo(new List<Client> {client});
        }

        [Test]
        public void should_not_transfer_client_to_another_department()
        {
            var managerSales = new Manager("Иванов", salesDepartment, Position.Manager);
            managerSales.AddClient(client);
            
            var managerSupport = new Manager("Петров", supportDepartment, Position.Manager);

            managerSales
                .Invoking(m => m.TransferClientTo(client, managerSupport))
                .ShouldThrow<TransferOutsiteTheDepartmentException>();
        }

        [Test]
        public void chief_of_another_department_cant_transfer_client()
        {
            var chief = new Manager("Иванов", supportDepartment, Position.DepartmentChief);

            chief
                .Invoking(m => m.TransferClientTo(client, targetManager))
                .ShouldThrow<TransferOutsiteTheDepartmentException>();
        }

        [Test]
        public void should_calculate_manager_bonus()
        {
            firstManager.ManagerBonus.Count.Should().Be(0);

            firstManager.TransferClientTo(client, targetManager);

            firstManager.ManagerBonus.Count.Should().Be(1);
        }
    }
}