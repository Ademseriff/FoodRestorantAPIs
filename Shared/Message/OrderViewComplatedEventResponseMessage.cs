using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Message
{
    public class OrderViewComplatedEventResponseMessage
    {
        public string TotalPrice { get; set; }

        public Category Category { get; set; }

        public string Product { get; set; }

        public string Email { get; set; }
        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public int OrderId { get; set; }
    }
}
