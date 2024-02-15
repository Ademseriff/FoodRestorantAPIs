using Shared.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class OrderViewComplatedEventResponse
    {
        public int id {  get; set; }

         public List<OrderViewComplatedEventResponseMessage> orderViewComplatedEventResponseMessages { get; set; }
    }
}
