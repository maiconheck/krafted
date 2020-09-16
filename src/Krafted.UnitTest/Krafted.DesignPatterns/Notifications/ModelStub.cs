using Krafted.DesignPatterns.Notifications;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Notifications
{
    public class ModelStub : Notifiable
    {
        public ModelStub(int age, string name)
        {
            Age = age;
            Name = name;

            Validate(this, new ModelStubValidator());
        }

        public int Age { get; }

        public string Name { get; }

        public new void AddNotification(string localizedMessage) => base.AddNotification(localizedMessage);
    }
}
