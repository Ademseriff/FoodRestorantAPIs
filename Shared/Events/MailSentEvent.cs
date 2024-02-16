using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class MailSentEvent
    {
        public int OrderId {  get; set; }

        public string EMail { get; set; }

        public State State { get; set; }

        
    }
}
