using Shared.Enums;
using Shared.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class OrderCreatedEvent
    {
        public int Id { get; set; }

        public State State { get; set; }

        public List<OrderCreatedEventMessage> OrderCreatedEventMessage { get; set; }
    }
}
