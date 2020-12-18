namespace Krafted.UnitTest.Krafted.DesignPatterns.Specifications
{
    public class ModelStub
    {
        public ModelStub(int age, string name, bool enabled = false)
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
