using System.Management.Instrumentation;
using NUnit.Framework;

namespace Crm
{
    [TestFixture]
    public class ClientTransferTest
    {
        [Test]
        public void should_transfer_client_from_one_manager_to_another()
        {
            var client = new Client {Name = "ООО Вектор Плюс"};
            var firstManager = new Manager("Петров");
            var targetManager = new Manager("Сидоров");
        }
    }
    
    public class Client
    {
        public string Name { get; set; }
    }

    public class Manager
    {
        public Manager(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
    }
}