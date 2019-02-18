using System;
using System.Linq;
using Flunt.Notifications;

namespace SharedKernel.Domain
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; set; }

        protected abstract void Validate();

        protected void AddNotificationsIfInvalid(params Notifiable[] items)
            => AddNotifications(items.Where(n => n.Invalid).ToArray());
    }
}