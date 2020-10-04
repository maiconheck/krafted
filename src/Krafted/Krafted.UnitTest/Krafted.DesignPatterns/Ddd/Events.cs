using Krafted.DesignPatterns.Ddd;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Ddd
{
    public class UserRegisteredEvent : IDomainEvent
    {
        public UserRegisteredEvent(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }

        public string Email { get; }
    }

    public class UserLockedEvent : IDomainEvent
    {
        public UserLockedEvent(string email) => Email = email;

        public string Email { get; }
    }
}
