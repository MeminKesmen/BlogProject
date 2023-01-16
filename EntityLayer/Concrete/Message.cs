using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message:IEntity
    {
        [Key]
        public int MessageId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.Now;
        public bool MessageStatus { get; set; } = false;
        public Writer SenderWriter { get; set; }
        public Writer ReceiverWriter { get; set; }
    }
}
