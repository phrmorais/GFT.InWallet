using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.InWallet.Domain.Entity
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        public string? Symbol { get; set; }
        public DateTime Inclusion { get; set; }
        public DateTime? Changed { get; set; }

        public abstract void Validate();
    }
}
