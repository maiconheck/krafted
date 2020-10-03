using Krafted.Ddd;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Ddd
{
    public class EntityStub : Entity
    {
        public override long Id { get; protected set; }

        public EntityStub(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age { get; }

        public string Name { get; }

        public void SetId(long id) => Id = id;
    }
}
