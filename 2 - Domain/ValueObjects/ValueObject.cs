using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.ValueObjects
{
    public abstract class ValueObject : Notifiable<Notification>
    {
        protected ValueObject()
        {
                
        }

    }
}
