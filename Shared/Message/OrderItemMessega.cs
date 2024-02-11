using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Message
{
    public class OrderItemMessega
    {
        public int Id { get; set; }
        public Category Category { get; set; }

        public string Price { get; set; }

        public string Product { get; set; }
    }
}
