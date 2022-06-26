using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GFT.InWallet.Domain.Entity
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        public string? Symbol { get; set; }
        [JsonIgnore]
        public DateTime Inclusion { get; set; }
        
        public abstract void IsValidate();
    }
}
