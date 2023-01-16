using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels
{
    public class MessageRequest
    {
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
    }
}
