namespace DomainModel.Tests
{
    using Crm;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class ManagerBonusTests
    {
        [Test]
        public void test_complex_bonus_logic()
        {
            var bonus = new ManagerBonus(new Manager("name", new Department("dep"), Position.Manager));

            bonus.IncreaseForClientTransfer();

            bonus.Count.Should().Be(1);
        }
    }
}