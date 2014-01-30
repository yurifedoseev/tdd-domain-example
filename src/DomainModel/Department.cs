namespace Crm
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        // TODO: override equal functions
    }
}