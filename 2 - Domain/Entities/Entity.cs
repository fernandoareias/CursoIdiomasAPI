using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Entities
{
    public abstract class Entity : Notifiable<Notification>, IEquatable<Entity>
    {
        public Entity()
        {
            
        }

        public Entity(long id)
        {
            Id = id;
        }
            
        public long Id { get; private set; }
        public bool Equals(Entity other) => Id == other.Id;
    }
}
