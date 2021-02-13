namespace Krafted.UnitTest
{
    public class EntityDummy
    {
        public EntityDummy(int age, string name, bool enabled = false)
        {
            Age = age;
            Name = name;
            Enabled = enabled;
        }

        public int Age { get; }

        public string Name { get; }

        public bool Enabled { get; }
    }
}
