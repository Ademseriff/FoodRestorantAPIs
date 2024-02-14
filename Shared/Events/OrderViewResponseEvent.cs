using Shared.Enums;
using Shared.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class OrderViewResponseEvent
    {
        public int Id { get; set; }

        public State State { get; set; }

        public List<OrderViewResponseEventMessage> OrderViewResponseEventMessage { get; set; }
    }
}
