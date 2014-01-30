namespace Crm
{
    internal class ManagerBonus
    {
        private readonly Manager manager;

        public ManagerBonus(Manager manager)
        {
            this.manager = manager;
        }

        public int Count { get; private set; }

        internal void IncreaseForClientTransfer()
        {
            // сложная логика, которая может зависеть от множества факторов
            Count++;
        }
    }
}