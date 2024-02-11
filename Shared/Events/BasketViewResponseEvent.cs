using Shared.Enums;
using Shared.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class BasketViewResponseEvent
    {
       
        public int Id { get; set; }

        public List<OrderItemMessega>  OrderItems { get; set; }
    }
}
