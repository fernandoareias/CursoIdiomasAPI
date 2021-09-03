
using Flunt.Notifications;

namespace Shared.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Id = System.Guid.NewGuid();
        }
        public System.Guid Id { get; private set; }
    }
}